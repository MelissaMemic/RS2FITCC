import 'dart:convert';

class AuthResult {
  late bool result;
  late String token;
  late String username;
  late bool isLockedOut;
  late bool isNotAllowed;
  late bool requiresTwoFactor;

  AuthResult() {  }

  AuthResult.full(this.result, this.token, this.username, this.isLockedOut, this.isNotAllowed, this.requiresTwoFactor);

  factory AuthResult.fromJson(Map<String, dynamic> map) {
    return AuthResult.full(
      map['result'],
      map['token'],
      map['username'],
      map['isLockedOut'],
      map['isNotAllowed'],
      map['requiresTwoFactor'],
    );
  }

  static AuthResult fromJsonString(String json) {
    final data = jsonDecode(json);
    return AuthResult.fromJson(data);
  }

  Map<String, dynamic> toJson() {
    return {
      'result': result,
      'token': token,
      'username': username,
      'isLockedOut': isLockedOut,
      'isNotAllowed': isNotAllowed,
      'requiresTwoFactor': requiresTwoFactor,
    };
  }

  String toJsonString() => jsonEncode(toJson());
}
