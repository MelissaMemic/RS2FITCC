
import 'package:json_annotation/json_annotation.dart';
part 'user.g.dart';

@JsonSerializable()
class User {
  //late int? userId;
  late String name;
  late String lastname;
  late bool isAllowed;
  late String username;
  late String website;
  late String role;

  User() {}

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);
  Map<String, dynamic> toJson() => _$UserToJson(this);

  // UserModel(this.name, this.lastname, this.isAllowed, this.username);

  // UserModel._fromResponse(
  //     this.userId, this.name, this.lastname, this.isAllowed, this.username);

  // @override
  // Map<String, dynamic> toJson() {
  //   return {
  //     "userId": userId,
  //     "name": name,
  //     "lastname": lastname,
  //     "isAllowed": isAllowed,
  //     "username": username,
  //   };
  // }

  // factory UserModel.fromJson(Map<String, dynamic> map) {
  //   return UserModel._fromResponse(
  //     map['user']['userId'],
  //     map['user']['name'].toString(),
  //     map['user']['lastname'].toString(),
  //     map['user']['isAllowed'],
  //     map['user']['username'].toString(),
  //   );
  // }

  // static UserModel resultFromJson(String json) {
  //   final data = JsonDecoder().convert(json);
  //   return UserModel.fromJson(data);
  // }
}
