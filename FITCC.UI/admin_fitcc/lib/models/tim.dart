import 'package:admin_fitcc/models/projekat.dart';
class Tim {
  late int timId;
  late String naziv;
  late int brojClanova;
  late int takmicenjeId;
  late int userId;
  late String username;
  List<Projekat> projekats = [];
  
  Tim({
    required this.timId,
    required this.naziv,
    required this.brojClanova,
    required this.takmicenjeId,
    required this.userId,
    required this.username,
    List<Projekat>? projekats,
  }) {
    if (projekats != null) {
      this.projekats = projekats;
    }
  }
   factory Tim.fromJson(Map<String, dynamic> json) {
    var projekatsJson = json['projekats'] as List<dynamic>;
    var projekatsList = projekatsJson.map((projekatJson) {
      return Projekat.fromJson(projekatJson as Map<String, dynamic>);
    }).toList();

    return Tim(
      timId: json['timId'] as int,
      naziv: json['naziv'] as String,
      brojClanova: json['brojClanova'] as int,
      takmicenjeId: json['takmicenjeId'] as int,
      userId: json['userId'] as int,
      username: json['username'] as String,
      projekats: projekatsList,
    );
  }
}
