import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/projekat.dart';
import 'package:admin_fitcc/models/tim.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';
import 'package:admin_fitcc/providers/projekat_provider.dart';
import 'package:admin_fitcc/providers/tim_provider.dart';
import 'package:flutter/material.dart';

class TimList extends StatefulWidget {
  @override
  _TimListState createState() => _TimListState();
}

class _TimListState extends State<TimList> {
  List<Tim> teamsList = [];
  List<Projekat> projectsList = [];
  List<Kategorija> kategorijeOptions = [];
  String selectedKategorija = 'All';
  Kategorija? latestKategorija;

  @override
  void initState() {
    super.initState();
    _fetchTeamsData();
    _fetchProjectsData();
    _fetchKategorijeOptions();
  }
Future<void> _fetchKategorijeOptions() async {
    try {
      List<Kategorija> fetchedKategorijeOptions =
          await KategorijaProvider().getKategorije();
      setState(() {
        kategorijeOptions.addAll(fetchedKategorijeOptions);
      });
    } catch (e) {
      print('Error fetching Kategorije options: $e');
    }
  }
  Future<void> _fetchTeamsData() async {
    try {
      List<Tim> fetchedTeamsList = await TimProvider().getAllTimData();
      setState(() {
        teamsList = fetchedTeamsList;
      });
    } catch (e) {
      print('Error fetching Teams data: $e');
    }
  }

  Future<void> _fetchProjectsData() async {
    try {
      List<Projekat> fetchedProjectsList =
          await ProjekatProvider().fetchProjekatiList();
      setState(() {
        projectsList = fetchedProjectsList;
      });
    } catch (e) {
      print('Error fetching Projects data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
   
    List<Tim> filteredTeamsList = teamsList
    .where((tim) => 
        selectedKategorija == "All" || 
        tim.projekats.any((projekat) => projekat.kategorijaId.toString() == selectedKategorija)
    )
    .toList();

    return Scaffold(
      appBar: AppBar(
        title: Text('Teams'),
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
         Padding(
            padding: const EdgeInsets.all(8.0),
            child: DropdownButton<String>(
              value: selectedKategorija,
              onChanged: (value) {
                setState(() {
                  selectedKategorija = value!;
                });
              },
              items: [
                DropdownMenuItem<String>(
                  value: 'All',
                  child: Text('Odaberi kategoriju'),
                ),
                ...kategorijeOptions.map((kategorija) {
                  return DropdownMenuItem<String>(
                    value: kategorija.kategorijaId.toString(),
                    child: Text(kategorija.naziv.toString()),
                  );
                }).toList(),
              ],
            ),
          ),
           Expanded(
            child: DataTable(
              columns: [
                DataColumn(label: Text('Tim Naziv')),
                DataColumn(label: Text('Broj clanova')),
              ],
              rows: filteredTeamsList.map((tim) {
                return DataRow(cells: [
                  DataCell(Text(tim.naziv)),
                  DataCell(Text(tim.brojClanova.toString())),
                ]);
              }).toList(),
            )
          ),
        ],
      ),
    );
  }
}
