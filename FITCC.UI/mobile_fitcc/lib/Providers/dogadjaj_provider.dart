import 'dart:convert';
import 'package:mobile_fitcc/Models/dogadjaj.dart';
import 'base_provider.dart';

class DogadjajProvider extends BaseProvider<Dogadjaj> {
  DogadjajProvider() : super("/api/Dogadjaj");

  Future<List> getDogadjeTakmicenja() async {
    var url = Uri.parse("http://10.0.2.2:5038/api/Dogadjaj/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}
