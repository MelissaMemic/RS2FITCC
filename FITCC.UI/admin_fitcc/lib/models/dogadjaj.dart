import 'dart:convert';
class Dogadjaj {
  late int dogadjajId;
  late String naziv;
late int? trajanje;
late DateTime? pocetak;
late DateTime? kraj;
  late String napomena; 
  late int agendaId;
  late String lokacija;

  Dogadjaj();

  Dogadjaj.full(this.dogadjajId, this.naziv, this.trajanje, this.pocetak, this.kraj,
      this.napomena, this.agendaId, this.lokacija);

  factory Dogadjaj.fromJson(Map<String, dynamic> map) {
    return Dogadjaj.full(
        map['dogadjajId'],
        map['naziv'],
        map['trajanje'],
        DateTime.tryParse(map['pocetak']),
        DateTime.tryParse(map['kraj']),
        map['napomena'],
        map['agendaId'],
        map['lokacija']);
  }

  static Dogadjaj DogadjajFromJson(String json) {
    final data = const JsonDecoder().convert(json);
    return Dogadjaj.fromJson(data);
  }
}
