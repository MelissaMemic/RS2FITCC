import 'dart:convert';
import 'package:admin_fitcc/models/uloge_komisije.dart';

import 'base_provider.dart';

class UlogeKomisijeProvider extends BaseProvider<UlogeKomisije> {
  UlogeKomisijeProvider() : super("api/Komisija");

  @override
  UlogeKomisije fromJson(data) {
    return UlogeKomisije.fromJson(data);
  }

  Future<List<UlogeKomisije>> fetchUlogeKomisijeList() async {
    var url = Uri.parse("https://127.0.0.1:7038/api/UlogeKomisije/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<UlogeKomisije>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}