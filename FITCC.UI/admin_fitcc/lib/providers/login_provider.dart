import 'dart:convert';
import 'dart:io';
import 'package:admin_fitcc/models/auth_request.dart';
import 'package:admin_fitcc/models/auth_response.dart';
import 'package:jwt_decoder/jwt_decoder.dart';

class LoginService {
  HttpClient client = HttpClient();
  AuthResult authResult = AuthResult.full(false, "", "", false, false, false);
  static final LoginService _instance = LoginService._privateConstructor();

  LoginService._privateConstructor();
  int userId = 0;
  String _username = "";
  String _password = "";

  factory LoginService() {
    return _instance;
  }

  Future<AuthResult?> loginAction(AuthRequest authRequest) async {
    client.badCertificateCallback =
        ((X509Certificate cert, String host, int port) => true);

    HttpClientRequest request =
        await client.postUrl(Uri.parse("http://localhost:5000/api/auth/login"));
    request.headers.set('Content-Type', 'application/json');
    request.add(utf8.encode(AuthRequest.loginToJson(authRequest)));
    HttpClientResponse result = await request.close();
print(result.statusCode);
    if (result.statusCode == 200) {
      final contents = StringBuffer();
      await for (var data in result.transform(utf8.decoder)) {
        contents.write(data);
      }
      _username = authRequest.username;
      _password = authRequest.password;
      authResult = AuthResult.fromJsonString(contents.toString());
      return authResult;
    }
    if (result.statusCode == 400) {
      return AuthResult.full(false, "", "", false, false, false);
    } else {
      final contents = StringBuffer();
      await for (var data in result.transform(utf8.decoder)) {
        contents.write(data);
      }

      throw HttpException(
          "Request failed. Status code: ${result.statusCode} ${contents}");
    }
  }

  bool isLoggedIn() {
    print(authResult.result);
    return authResult.result;
  }

  void verifySession() {
    if (isExpiredToken()) {
      loginAction(AuthRequest(_username, _password));
    }
  }

  bool isExpiredToken() {
    return JwtDecoder.isExpired(authResult.token);
  }

  String getToken() {
    return authResult.token;
  }

  String getUserName() {
    return authResult.username;
  }

  AuthResult getAuthResult() {
    return authResult;
  }

  void setResponseFalse() {
    authResult.result = false;
  }
}