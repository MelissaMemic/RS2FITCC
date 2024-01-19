import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/projekat.dart';
import 'package:mobile_fitcc/Models/projekt_tim.dart';
import 'package:mobile_fitcc/Models/tim.dart';
import 'package:mobile_fitcc/Providers/projekat_provider.dart';
import 'package:mobile_fitcc/Providers/tim_provider.dart';
import 'package:mobile_fitcc/Screens/ocjenjivanje_projekata.dart';


  class PregledProjekataScreen extends StatefulWidget {
  @override
  _PregledProjekataScreenState createState() => _PregledProjekataScreenState();
}

class _PregledProjekataScreenState extends State<PregledProjekataScreen> {
 List<Projekat> projekti = [  ];
 List<ProjekatTimInfo> combinedLista = [  ];
 List<Tim> timovi = [  ];
@override
  void initState() {
    super.initState();
    _fetchProjekatData();
  }

  Future<void> _fetchProjekatData() async {
    try {
      List<Projekat> fetchedprojektiList = await ProjekatProvider().get();
      List<Tim> fetchedtimoviList = await TimProvider().get();

      List<ProjekatTimInfo> newCombinedList = [];
    var timMap = {for (var tim in fetchedtimoviList) tim.timId: tim};


    for (var projekat in fetchedprojektiList) {
      Tim correspondingTim = timMap[projekat.timId] ?? Tim(timId:1,naziv: 'test',brojClanova:1,userId:1,username: 'name',takmicenjeId: 1); // Provide a default Tim object if not found

        newCombinedList.add(ProjekatTimInfo(projekat: projekat, tim: correspondingTim)); 
    }
      setState(() {
        projekti = fetchedprojektiList;
        timovi = fetchedtimoviList;
        combinedLista = newCombinedList;
      });
    } catch (e) {
      print('Error fetching Projekat data: $e');
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
                  DataColumn(label: Text('Naziv')),
                  DataColumn(label: Text('Opis')),
                  DataColumn(label: Text(' ')),
                ],
                rows: combinedLista.map((projekat) {
                  return DataRow(cells: [
                    DataCell(Text(projekat.projekat.naziv)),
                    DataCell(Text(projekat.tim.naziv)),
                    DataCell(
                    ElevatedButton(
                      onPressed: () {
                        Navigator.push(
                          context,
                          MaterialPageRoute(builder: (context) => OcjenjivanjeProjektaScreen( projekat: projekat.projekat)),
                        );
                      },
                      child: Text('Ocjeni'),
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