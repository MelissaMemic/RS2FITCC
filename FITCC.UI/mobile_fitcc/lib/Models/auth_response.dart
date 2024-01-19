import 'dart:convert';

class AuthResponse {
  bool result;
  String token;
  String username;
  bool isLockedOut;
  bool isNotAllowed;
  bool requiresTwoFactor;

  AuthResponse(this.result, this.token, this.username, this.isLockedOut,
      this.isNotAllowed, this.requiresTwoFactor);

  factory AuthResponse.fromJson(Map<String, dynamic> map) {
    return AuthResponse(map['result'], map['token'], map['username'],
        map['isLockedOut'], map['isNotAllowed'], map['requiresTwoFactor']);
  }

  static AuthResponse authResultFromJson(String json) {
    final data = const JsonDecoder().convert(json);
    return AuthResponse.fromJson(data);
  }
}
