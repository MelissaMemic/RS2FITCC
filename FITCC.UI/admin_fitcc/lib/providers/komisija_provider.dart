import 'dart:convert';
import '../models/komisija.dart';
import 'base_provider.dart';

class KomisijaProvider extends BaseProvider<Komisija> {
  KomisijaProvider() : super("api/Komisija");

  @override
  Komisija fromJson(data) {
    return Komisija.fromJson(data);
  }

  Future<List<Komisija>> fetchKomisijaList() async {
    var url = Uri.parse("https://127.0.0.1:7038/api/Komisija/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Komisija>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}