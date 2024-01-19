import 'dart:convert';
import 'package:mobile_fitcc/Models/rezultat.dart';
import 'base_provider.dart';

class RezultatProvider extends BaseProvider<Rezultat> {
  RezultatProvider() : super("api/Rezultati");

  @override
  Rezultat fromJson(data) {
    return Rezultat.fromJson(data);
  }

  Future<List<Rezultat>> fetchRezultatiList() async {
    var url = Uri.parse("https://10.0.2.2:7038/api/Rezultati");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Rezultat>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }

  Future<List<Rezultat>> getAllRezultati() async {
    var url = Uri.parse("https://10.0.2.2:7038/api/Rezultati/getAllRezultati");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Rezultat>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }

}