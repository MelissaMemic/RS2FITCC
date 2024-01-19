// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User()
  ..name = json['name'] as String
  ..lastname = json['lastname'] as String
  ..isAllowed = json['isAllowed'] as bool
  ..username = json['username'] as String
  ..website = json['website'] as String
  ..role = json['role'] as String;

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'name': instance.name,
      'lastname': instance.lastname,
      'isAllowed': instance.isAllowed,
      'username': instance.username,
      'website': instance.website,
      'role': instance.role,
    };
