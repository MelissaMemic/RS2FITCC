import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/user.dart';
import 'package:mobile_fitcc/Providers/user_provider.dart';
import 'package:mobile_fitcc/Screens/takmicar_detalji.dart';

class PregledTakmicaraScreen extends StatefulWidget {
  @override
  _PregledTakmicaraScreenState createState() => _PregledTakmicaraScreenState();
}

class _PregledTakmicaraScreenState extends State<PregledTakmicaraScreen> {
  List<User> korisnici = [];

  @override
  void initState() {
    super.initState();
    _fetchUserData();
  }

  Future<void> _fetchUserData() async {
    try {
      List<User> fetchedTakmicari =
          await UserProvider().getAllByRole("takmicar");
      setState(() {
        korisnici = fetchedTakmicari;
      });
    } catch (e) {
      print('Error fetching Takmicari: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
          ),
          Expanded(
            child: DataTable(
              columns: [
                DataColumn(label: Text('Ime Prezime')),
                DataColumn(label: Text('Webb')),
                DataColumn(label: Text(' ')),
              ],
              rows: korisnici.map((korisnik) {
                return DataRow(cells: [
                  DataCell(Text('${korisnik.name} - ${korisnik.lastname}')),
                  DataCell(Text(korisnik.website)),
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) =>
                                  TakmicarDetaljiScreen(takmicar: korisnik)),
                        );
                      },
                      child: Text('CV'),
                    ),
                  ),
                ]);
              }).toList(),
            ),
          ),
        ],
      ),
    );
  }
}
