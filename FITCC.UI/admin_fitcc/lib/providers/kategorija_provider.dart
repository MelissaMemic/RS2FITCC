import 'dart:convert';

import 'package:admin_fitcc/models/kategorija_test.dart';
import 'package:admin_fitcc/providers/login_provider.dart';
import 'package:http/http.dart' as http;
import '../models/kategorija.dart';
import 'base_provider.dart';

class KategorijaProvider extends BaseProvider<Kategorija> {
  KategorijaProvider() : super("api/Kategorija");
  LoginService _loginService = LoginService();

  @override
  Kategorija fromJson(data) {
    return Kategorija.fromJson(data);
  }
Future<KategorijaTest?> getLatestKategorija() async {
      // _loginService.verifySession();

  var url = Uri.parse("https://localhost:7038/api/Kategorija/getLast");

  Map<String, String> headers = createHeaders();

  var response = await http.get(url, headers: headers);

  if (isValidResponseCode(response)) {
    var data = jsonDecode(response.body);

    if (data is List && data.isNotEmpty) {
      return KategorijaTest.fromJson(data.first);
    }

    return KategorijaTest.fromJson(data);
  } else {
    throw Exception("Dogodila se greska");
  }
}

  Future<List<Kategorija>> getKategorije() async {
          // _loginService.verifySession();

    var url = Uri.parse("https://localhost:7038/api/Kategorija/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map<Kategorija>((x) => Kategorija.fromJson(x)).toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}
