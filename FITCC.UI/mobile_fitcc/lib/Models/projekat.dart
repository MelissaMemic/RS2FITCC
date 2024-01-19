
import 'package:mobile_fitcc/Models/rezultat.dart';

class Projekat {
  final int projekatId;
  final String naziv;
  final String opis;
  final int kategorijaId;
  final int timId;
  final int userId;
  final String username;
  final dynamic kategorija; 
  final dynamic tim; 
    final List<Rezultat> rezultats; // Add this line

  Projekat({
    required this.projekatId,
    required this.naziv,
    required this.opis,
    required this.kategorijaId,
    required this.timId,
    required this.userId,
    required this.username,
    required this.kategorija,
    required this.tim,
    required this.rezultats,
  });

  factory Projekat.fromJson(Map<String, dynamic> json) {
   var rezultatsFromJson = json['rezultats'] as List<dynamic>;
    var rezultatList = rezultatsFromJson.map((jsonItem) => Rezultat.fromJson(jsonItem)).toList();

 return Projekat(
      projekatId: json['projekatId'] as int,
      naziv: json['naziv'] as String,
      opis: json['opis'] as String,
      kategorijaId: json['kategorijaId'] as int,
      timId: json['timId'] as int,
      userId: json['userId'] as int,
      username: json['username'] as String,
      kategorija: json['kategorija'],
      tim: json['tim'],
      rezultats: rezultatList
    );
  }
}
