import 'dart:convert';
import 'package:admin_fitcc/models/agenda.dart';
import 'base_provider.dart';

class AgendaProvider extends BaseProvider<Agenda> {
  AgendaProvider() : super("api/Agenda");

  @override
  Agenda fromJson(data) {
    return Agenda.fromJson(data);
  }

  Future<List<Agenda>> fetchAgendaList() async {
    var url = Uri.parse("https://localhost:7038/api/Agenda/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Agenda>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
  
}