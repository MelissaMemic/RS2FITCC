import 'dart:convert';

class Napomena {
  late int napomenaId;
  late String poruka;
  late String? usernameTakmicar;
  late String? userName;

  Napomena();

  Napomena.full(
    this.napomenaId,
    this.poruka,
    this.usernameTakmicar,
    this.userName,
  );

  factory Napomena.fromJson(Map<String, dynamic> json) {
    return Napomena.full(
      json['napomenaId'],
      json['poruka'],
      json['usernameTakmicar'],
      json['userName'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'napomenaId': napomenaId,
      'poruka': poruka,
      'usernameTakmicar': usernameTakmicar,
      'userName': userName,
    };
  }

  static Napomena fromJsonString(String jsonString) {
    final Map<String, dynamic> data = jsonDecode(jsonString);
    return Napomena.fromJson(data);
  }
}
