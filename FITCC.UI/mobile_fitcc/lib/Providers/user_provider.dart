import 'dart:convert';
import 'package:mobile_fitcc/Models/user.dart';
import 'package:mobile_fitcc/providers/login_provider.dart';

import 'base_provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("/api/UserM");
  String name = "";

  Future<dynamic> getUserData() async {
    name = LoginService().getUserName();
    var url = Uri.parse(
        "https://10.0.2.2:7038/api/UserM/GetByUsername?username=$name");
    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Dogodila se greska");
    }
  }

  Future<User> getUser(String ime) async {
    var url = Uri.parse(
        "https://10.0.2.2:7038/api/UserM/GetByUsername?username=$ime");
    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);
    if (response.statusCode == 200) {
      dynamic jsonItem = json.decode(response.body);

      User user = User.fromJson(jsonItem);
      return user;
    } else {
      throw Exception('Failed to load users');
    }
  }

  Future<List<User>> getAllByRole(String role) async {
    var url =
        Uri.parse("https://10.0.2.2:7038/api/UserM/getAllByRole?role=$role");
    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);
    if (response.statusCode == 200) {
      List<dynamic> jsonList = json.decode(response.body);

      List<User> users =
          jsonList.map((jsonItem) => User.fromJson(jsonItem)).toList();
      return users;
    } else {
      throw Exception('Failed to load users');
    }
  }

  Future<String> getWebsite(String username) async {
    var url = Uri.parse(
        "https://10.0.2.2:7038/api/UserM/GetWebsiteByUsername?username=$username");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);
    String rspbody = response.body;

    return rspbody;
  }

  Future<bool> checkRole(String username, String role) async {
    var url = Uri.parse(
        "https://10.0.2.2:7038/api/UserM/CheckRoleByUser?username=$username&role=$role");

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
