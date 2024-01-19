import 'dart:convert';

class Agenda {
  late int agendaId;
  late int dan;
  late int takmicenjeId;

  Agenda(this.agendaId, this.dan, this.takmicenjeId);

  factory Agenda.fromJson(Map<String, dynamic> map) {
    return Agenda(
        map['agendaId'],
        map['dan'],
        map['takmicenjeId']
       );
  }

  static Agenda DogadjajFromJson(String json) {
    final data = const JsonDecoder().convert(json);
    return Agenda.fromJson(data);
  }
}
