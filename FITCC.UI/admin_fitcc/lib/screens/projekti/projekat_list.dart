import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/projekat.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';
import 'package:admin_fitcc/providers/projekat_provider.dart';
import 'package:flutter/material.dart';

class ProjekatList extends StatefulWidget {
  @override
  _ProjekatListState createState() => _ProjekatListState();
}

class _ProjekatListState extends State<ProjekatList> {
  List<Projekat> projektiList = [];
  List<Kategorija> kategorijeOptions = [];
  String selectedKategorija = 'All';
  Kategorija? latestKategorija;

  @override
  void initState() {
    super.initState();
    _fetchProjekatData();
    _fetchKategorijeOptions();
  }

  Future<void> _fetchProjekatData() async {
    try {
      List<Projekat> fetchedprojektiList = await ProjekatProvider().get();
      setState(() {
        projektiList = fetchedprojektiList;
      });
    } catch (e) {
      print('Error fetching Projekat data: $e');
    }
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

  @override
  Widget build(BuildContext context) {
    List<Projekat> filteredProjektiList = projektiList
        .where((projekat) =>
            selectedKategorija == 'All' ||
            projekat.kategorijaId == int.parse(selectedKategorija))
        .toList();

    return Scaffold(
      appBar: AppBar(
        title: Text('Projekti'),
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
                    child: Text(kategorija.naziv),
                  );
                }).toList(),
              ],
            ),
          ),
          Expanded(
              child: DataTable(
                columns: [
                  DataColumn(label: Text('Naziv')),
                  DataColumn(label: Text('Opis')),
                  DataColumn(label: Text('Tim ID')),
                ],
                rows: filteredProjektiList.map((projekat) {
                  return DataRow(cells: [
                    DataCell(Text(projekat.naziv)),
                    DataCell(Text(projekat.opis)),
                    DataCell(Text(projekat.timId.toString())),
                  ]);
                }).toList(),
              ),
          ),
        ],
      ),
    );
  }

}
