import 'dart:convert';

class Kategorija {
  late int kategorijaId;
  late String naziv;
  late String? opis;
  late int? takmicenjeId;

  Kategorija(this.kategorijaId, this.naziv,this.opis, this.takmicenjeId);
  Kategorija.full(){}

  factory Kategorija.fromJson(Map<String, dynamic> map) {
    return Kategorija(
        map['kategorijaId'],
        map['naziv'],
        map['opis'],
        map['takmicenjeId']);
  }
  static Kategorija KategorijaFromJson(String json) {
    final data = const JsonDecoder().convert(json);
    return Kategorija.fromJson(data);
  }
}
