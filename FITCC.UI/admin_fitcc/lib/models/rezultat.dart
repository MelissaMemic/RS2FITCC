import 'dart:convert';
import 'package:admin_fitcc/models/projekat.dart';

class Rezultat {
  late int rezultatId;
  late int bod;
  late String napomena;
  late int projekatId;
  late Projekat? projekat; 

  Rezultat(
    this.rezultatId,
    this.bod,
    this.napomena,
    this.projekatId,
    this.projekat,
  );

  factory Rezultat.fromJson(Map<String, dynamic> map) {
    return Rezultat(
      map['rezultatId'],
      map['bod'],
      map['napomena'],
      map['projekatId'],
      map['projekat'] != null ? Projekat.fromJson(map['projekat']) : null,

    );
  }

  static Rezultat rezultatFromJson(String json) {
    final Map<String, dynamic> data = jsonDecode(json);
    return Rezultat.fromJson(data);
  }
}
