import 'dart:convert';
import 'dart:io';
import 'package:mobile_fitcc/Models/auth_request.dart';
import 'package:mobile_fitcc/Models/auth_response.dart';
import 'package:jwt_decoder/jwt_decoder.dart';

class LoginService {
  HttpClient _client = HttpClient();
  AuthResponse _authResponse = AuthResponse(false, "", "", false, false, false);
  static final LoginService _instance = LoginService._privateConstructor();

  LoginService._privateConstructor();
  int userId = 0;
  String _username = "";
  String _password = "";

  factory LoginService() {
    return _instance;
  }

  Future<AuthResponse?> loginAction(AuthRequest authRequest) async {
    _client.badCertificateCallback =
        ((X509Certificate cert, String host, int port) => true);

    HttpClientRequest request =
        await _client.postUrl(Uri.parse("https://10.0.2.2:5443/api/auth/login"));
    request.headers.set('Content-Type', 'application/json');
    request.add(utf8.encode(AuthRequest.loginToJson(authRequest)));
    HttpClientResponse result = await request.close();

    if (result.statusCode == 200) {
      final contents = StringBuffer();
      await for (var data in result.transform(utf8.decoder)) {
        contents.write(data);
      }
      _username = authRequest.username;
      _password = authRequest.password;
      _authResponse = AuthResponse.authResultFromJson(contents.toString());
      return _authResponse;
    }
    if (result.statusCode == 400) {
      return AuthResponse(false, "", "", false, false, false);
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
    return _authResponse.result;
  }

  void verifySession() {
    if (isExpiredToken()) {
      loginAction(AuthRequest(_username, _password));
    }
  }

  bool isExpiredToken() {
    return JwtDecoder.isExpired(_authResponse.token);
  }

  String getToken() {
    return _authResponse.token;
  }

  String getUserName() {
    return _authResponse.username;
  }

  AuthResponse getAuthResponse() {
    return _authResponse;
  }

  void setResponseFalse() {
    _authResponse.result = false;
  }
}