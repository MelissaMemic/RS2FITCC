import 'dart:convert';
import 'package:mobile_fitcc/Models/tim.dart';
import 'base_provider.dart';

class TimProvider extends BaseProvider<Tim> {
  TimProvider() : super("api/Tim");

  @override
  Tim fromJson(data) {
    return Tim.fromJson(data);
  }

  Future<List<Tim>> fetchTimoviList() async {
    var url = Uri.parse("https://10.0.2.2:7038/api/Tim/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Tim>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
   Future<List<Tim>> getAllTimData({String? searchText}) async {
    var url = Uri.parse("https://10.0.2.2:7038/api/Tim/getAllTimData");

    Map<String, String> headers = createHeaders();

    if (searchText != null) {
      url = Uri.parse('$url?searchText=$searchText');
    }

    var response = await http!.get(url, headers: headers);

    if (response.statusCode == 200) {
      var data = jsonDecode(response.body);
      return data.map((x) => Tim.fromJson(x)).cast<Tim>().toList();
    } else {
      throw Exception("An error occurred while fetching Tim data");
    }
  }
}