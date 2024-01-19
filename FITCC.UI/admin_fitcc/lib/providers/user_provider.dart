import 'dart:convert';
import 'dart:io';

import 'package:admin_fitcc/models/user.dart';
import 'package:admin_fitcc/providers/login_provider.dart';

import 'base_provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("/api/UserM");
  String name = "";

  HttpClient client = HttpClient();

  Future<dynamic> getUserData() async {
    name = LoginService().getUserName();
    var url = Uri.parse(
        "https://127.0.0.1:7038/api/UserM/GetByUsername?username=$name");
    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Dogodila se greska");
    }
  }

  Future<String> getWebsite(String username) async {
    var url = Uri.parse(
        "https://127.0.0.1:7038/api/UserM/GetWebsiteByUsername?username=$username");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);
    String rspbody = response.body;

    return rspbody;
    // if (isValidResponseCode(response)) {
    //   //var data = jsonDecode(rspbody);
    //   return rspbody;
    // } else {
    //   throw Exception("Dogodila se greska");
    // }
  }

  Future<bool> checkRole(String username, String role) async {
    var url = Uri.parse(
        "https://127.0.0.1:7038/api/UserM/CheckRoleByUser?username=$username&role=$role");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}
