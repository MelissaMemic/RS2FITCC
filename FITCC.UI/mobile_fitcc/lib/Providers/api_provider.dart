import 'dart:convert';
import 'dart:io';
import 'package:mobile_fitcc/providers/login_provider.dart';

class ApiService {
  LoginService _loginService = LoginService();
  String _baseApiUrl = "https://10.0.2.2:7038";

  Future<String> post(String path, String body) async {
   // _loginService.verifySession();
    var client = new HttpClient();
    client.badCertificateCallback =
        ((X509Certificate cert, String host, int port) => true);

    HttpClientRequest request =
        await client.postUrl(Uri.parse("https://10.0.2.2:7038/$path"));
    request.headers.set('Content-Type', 'application/json');
    request.headers.set('Authorization', 'Bearer ${_loginService.getToken()}');
    request.add(utf8.encode(body));
    HttpClientResponse result = await request.close();

    if (result.statusCode == 200) {
      final contents = StringBuffer();
      await for (var data in result.transform(utf8.decoder)) {
        contents.write(data);
      }
      return contents.toString();
    } else {
      throw HttpException("Request failed. Status code: ${result.statusCode}");
    }
  }

  Future<String> put(String path, String body) async {
    //_loginService.verifySession();
    var client = new HttpClient();
    client.badCertificateCallback =
        ((X509Certificate cert, String host, int port) => true);

    HttpClientRequest request =
        await client.putUrl(Uri.parse("$_baseApiUrl/$path"));
    request.headers.set('Content-Type', 'application/json');
    request.headers.set('Authorization', 'Bearer ${_loginService.getToken()}');
    request.add(utf8.encode(body));
    HttpClientResponse result = await request.close();

    if (result.statusCode == 200) {
      _loginService.verifySession();
      final contents = StringBuffer();
      await for (var data in result.transform(utf8.decoder)) {
        contents.write(data);
      }
      return contents.toString();
    } else {
      final contents = StringBuffer();
      await for (var data in result.transform(utf8.decoder)) {
        contents.write(data);
      }
      throw HttpException(
          "Request failed. Status code: ${result.statusCode} ${contents}");
    }
  }

  Future<String> get(String path) async {
    _loginService.verifySession();
    var client = new HttpClient();
    client.badCertificateCallback =
        ((X509Certificate cert, String host, int port) => true);

    HttpClientRequest request =
        await client.getUrl(Uri.parse("$_baseApiUrl/$path"));
    request.headers.set('Content-Type', 'application/json');
    request.headers.set('Authorization', 'Bearer ${_loginService.getToken()}');
    HttpClientResponse result = await request.close();

    if (result.statusCode == 200) {
      final contents = StringBuffer();
      await for (var data in result.transform(utf8.decoder)) {
        contents.write(data);
      }
      return contents.toString();
    } else {
      throw HttpException("Request failed. Status code: ${result.statusCode}");
    }
  }

  Future<String> delete(String path) async {
    _loginService.verifySession();
    var client = new HttpClient();
    client.badCertificateCallback =
        ((X509Certificate cert, String host, int port) => true);

    HttpClientRequest request =
        await client.deleteUrl(Uri.parse("$_baseApiUrl/$path"));
    request.headers.set('Content-Type', 'application/json');
    request.headers.set('Authorization', 'Bearer ${_loginService.getToken()}');
    HttpClientResponse result = await request.close();

    if (result.statusCode == 200) {
      final contents = StringBuffer();
      await for (var data in result.transform(utf8.decoder)) {
        contents.write(data);
      }
      return contents.toString();
    } else {
      throw HttpException("Request failed. Status code: ${result.statusCode}");
    }
  }
}