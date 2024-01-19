import 'dart:convert';

import 'package:admin_fitcc/models/kategorija.dart';

class Kriterij {
  late int kriterijId;
  late String naziv;
  late String vrijednost;
  late int kategorijaId;
  late Kategorija kategorija;

  Kriterij();

  Kriterij.full(
    this.kriterijId,
    this.naziv,
    this.vrijednost,
    this.kategorijaId,
    this.kategorija,
  );

  factory Kriterij.fromJson(Map<String, dynamic> map) {
    return Kriterij.full(
      map['kriterijId'] ,
      map['naziv'] ,
      map['vrijednost'] ,
      map['kategorijaId'],
      map['kategorija'],
    );
  }

  static Kriterij kriterijFromJson(String json) {
    final data = jsonDecode(json);
    return Kriterij.fromJson(data);
  }

  Map<String, dynamic> toJson() {
    return {
      'kriterijId': kriterijId,
      'naziv': naziv,
      'vrijednost': vrijednost,
      'kategorijaId': kategorijaId,
      'kategorija': kategorija 
    };
  }
}
