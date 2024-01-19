import 'package:mobile_fitcc/providers/login_provider.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:http/io_client.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  static String? _baseUrl;
  String? _endpoint;

  HttpClient client = new HttpClient();
  LoginService _loginService = LoginService();
  IOClient? http;

  BaseProvider(String endpoint) {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://10.0.2.2:7038/");
    print("baseurl: $_baseUrl");

    if (_baseUrl!.endsWith("/") == false) {
      _baseUrl = _baseUrl! + "/";
    }

    _endpoint = endpoint;
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }
Future<void> delete(int id) async {
    try {
      _loginService.verifySession();
      var url = "$_baseUrl$_endpoint/$id";
      var uri = Uri.parse(url);

      Map<String, String> headers = createHeaders();
      var response = await http!.delete(uri, headers: headers);

      if (!isValidResponseCode(response)) {
        throw Exception("Failed to delete item");
      }
    } catch (e) {
      print("Error deleting item: $e");
      throw Exception("Failed to delete item");
    }
  }
Future<T> getById(int id, [dynamic additionalData]) async {
 // _loginService.verifySession();
  var url = Uri.parse("$_baseUrl$_endpoint/$id");

  Map<String, String> headers = createHeaders();

  var response = await http!.get(url, headers: headers);

  if (isValidResponseCode(response)) {
    var data = jsonDecode(response.body);
    return fromJson(data);
  } else {
    throw Exception("Dogodila se greska");
  }
}


  Future<List<T>> get([dynamic search]) async {
    //_loginService.verifySession();
    var url = "$_baseUrl$_endpoint";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<T>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
Future<T?> insert(dynamic request) async {
   // _loginService.verifySession();
    var url = "$_baseUrl$_endpoint";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var jsonRequest = jsonEncode(request);
    var response = await http!.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data) as T;
    } else {
      return null;
    }
  }
  Future<T?> update(int id, [dynamic request]) async {
    _loginService.verifySession();
    var url = "$_baseUrl$_endpoint/$id";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response =
        await http!.put(uri, headers: headers, body: jsonEncode(request));

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data) as T;
    } else {
      return null;
    }
  }

  T fromJson(data) {
    throw Exception("Override method");
  }

  Map<String, String> createHeaders() {
    var headers = {
      "Content-Type": "application/json",
      "Authorization": 'Bearer ${_loginService.getToken()}'
    };
    return headers;
  }

  String getQueryString(Map params,
      {String prefix= '&', bool inRecursion= false}) {
    String query = '';
    params.forEach((key, value) {
      if (inRecursion) {
        if (key is int) {
          key = '[$key]';
        } else if (value is List || value is Map) {
          key = '.$key';
        } else {
          key = '.$key';
        }
      }
      if (value is String || value is int || value is double || value is bool) {
        var encoded = value;
        if (value is String) {
          encoded = Uri.encodeComponent(value);
        }
        query += '$prefix$key=$encoded';
      } else if (value is DateTime) {
        query += '$prefix$key=${(value as DateTime).toIso8601String()}';
      } else if (value is List || value is Map) {
        if (value is List) value = value.asMap();
        value.forEach((k, v) {
          query +=
              getQueryString({k: v}, prefix: '$prefix$key', inRecursion: true);
        });
      }
    });
    return query;
  }

  bool isValidResponseCode(Response response) {
    if (response.statusCode == 200) {
      if (response.body != "") {
        return true;
      } else {
        return false;
      }
    } else if (response.statusCode == 204) {
      return true;
    } else if (response.statusCode == 400) {
      throw Exception("Bad request");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else if (response.statusCode == 403) {
      throw Exception("Forbidden");
    } else if (response.statusCode == 404) {
      throw Exception("Not found");
    } else if (response.statusCode == 500) {
      throw Exception("Internal server error");
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}