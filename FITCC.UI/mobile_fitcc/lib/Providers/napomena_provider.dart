import 'dart:convert';

import 'package:mobile_fitcc/Models/napomena.dart';
import 'base_provider.dart';

class NapomenaProvider extends BaseProvider<Napomena> {
  NapomenaProvider() : super("api/Napomena");

  @override
  Napomena fromJson(data) {
    return Napomena.fromJson(data);
  }
Future<bool> sendContactEmail(Map<String, dynamic> emailData) async {
  var url = Uri.parse('https://10.0.2.2:7038/api/Napomena/SendContactEmail');
  var headers = {'Content-Type': 'application/json'};
  var body = json.encode({
    'from': emailData['sender'],
    'to': emailData['recipient'],
    'subject': emailData['subject'],
    'body': emailData['content']
  });

  try {
    var response = await http!.post(url, headers: headers, body: body);

    if (response.statusCode == 200) {
      print('Email sent successfully.');
      return true;
    } else {
      print('Failed to send email. Status code: ${response.statusCode}');
      return false;
    }
  } catch (e) {
    print('An error occurred: $e');
    return false;
  }
}
}