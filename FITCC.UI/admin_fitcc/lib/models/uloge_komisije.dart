import 'dart:convert';

class UlogeKomisije {
  late int ulogeKomisijeId;
  late String naziv;

  UlogeKomisije(this.ulogeKomisijeId, this.naziv);

  factory UlogeKomisije.fromJson(Map<String, dynamic> map) {
    return UlogeKomisije(
        map['ulogeKomisijeId'],
        map['naziv']);
  }

  static UlogeKomisije DogadjajFromJson(String json) {
    final data = const JsonDecoder().convert(json);
    return UlogeKomisije.fromJson(data);
  }
}
