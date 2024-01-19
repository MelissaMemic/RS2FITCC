import 'dart:convert';

import 'package:json_annotation/json_annotation.dart';

@JsonSerializable()
class User {
  late String name;
  late String lastname;
  late bool isAllowed;
  late String username;
  late String website;
  late String role;

  User();
  User.full(
    this.name,
    this.lastname,
    this.isAllowed,
    this.username,
    this.website,
    this.role
  );

  factory User.fromJson(Map<String, dynamic> json) {
    return User.full(
      json['name'],
      json['lastname'],
      json['isAllowed'],
      json['username'],
      json['website'],
      json['role']
    );
  }


  // factory User.fromJson(Map<String, dynamic> json) => User()
  //   ..name = json['name'] as String
  //   ..lastname = json['lastname'] as String
  //   ..isAllowed = json['isAllowed'] as bool
  //   ..username = json['username'] as String
  //   ..website = json['website'] as String
  //   ..role = json['role'] as String;

  Map<String, dynamic> toJson() => <String, dynamic>{
        'name': name,
        'lastname': lastname,
        'isAllowed': isAllowed,
        'username': username,
        'website': website,
        'role': role,
      };
        static User fromJsonString(String jsonString) {
    final Map<String, dynamic> data = jsonDecode(jsonString);
    return User.fromJson(data);
  }

}
