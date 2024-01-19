import 'dart:convert';
import 'package:admin_fitcc/models/dogadjaj.dart';
import 'base_provider.dart';

class DogadjajProvider extends BaseProvider<Dogadjaj> {
  DogadjajProvider() : super("api/Dogadjaj");

  @override
  Dogadjaj fromJson(data) {
    return Dogadjaj.fromJson(data);
  }

  Future<List<Dogadjaj>> fetchDogadjajList() async {
    var url = Uri.parse("https://127.0.0.1:7038/api/Dogadjaj/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Dogadjaj>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }

}