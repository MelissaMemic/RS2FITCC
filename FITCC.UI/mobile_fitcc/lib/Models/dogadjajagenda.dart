
import 'dart:convert';

class DogadjajiPerAgenda {
  late int agendaId;
  late int? dan;
  late int? takmicenjeId;
  late int dogadjajId;
  late String naziv;
  late int? trajanje;
  late DateTime? pocetak;
  late DateTime? kraj;
  late String? napomena;
  late String lokacija;

  DogadjajiPerAgenda({
    required this.agendaId,
    required this.dan,
    required this.takmicenjeId,
    required this.dogadjajId,
    required this.naziv,
    required this.trajanje,
    required this.pocetak,
    required this.kraj,
    required this.napomena,
    required this.lokacija,
  });

  factory DogadjajiPerAgenda.fromJson(Map<String, dynamic> map) {
    return DogadjajiPerAgenda(
      agendaId: map['agendaId'],
      dan: map['dan'],
      takmicenjeId: map['takmicenjeId'],
      dogadjajId: map['dogadjajId'],
      naziv: map['naziv'],
      trajanje: map['trajanje'],
      pocetak: map['pocetak'] != null ? DateTime.parse(map['pocetak']) : null,
      kraj: map['kraj'] != null ? DateTime.parse(map['kraj']) : null,
      napomena: map['napomena'],
      lokacija: map['lokacija'],
    );
  }

  static DogadjajiPerAgenda fromJsonString(String jsonString) {
    final Map<String, dynamic> data = json.decode(jsonString);
    return DogadjajiPerAgenda.fromJson(data);
  }
}
