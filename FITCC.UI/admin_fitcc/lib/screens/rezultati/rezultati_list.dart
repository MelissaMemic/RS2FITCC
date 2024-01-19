import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/projekat.dart';
import 'package:admin_fitcc/models/rezultat.dart';
import 'package:admin_fitcc/providers/rezultat_provider.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';
import 'package:flutter/material.dart';

class RezultatiList extends StatefulWidget {
  @override
  _RezultatiListState createState() => _RezultatiListState();
}

class _RezultatiListState extends State<RezultatiList> {
  List<Rezultat> rezultatiList = [];
  List<Projekat> projectsList = [];
  List<Kategorija> kategorijeOptions = [];
  String selectedKategorija = 'All';
  Kategorija? latestKategorija;

  @override
  void initState() {
    super.initState();
    _fetchRezultatiData();
    _fetchKategorijeOptions();
  }

  Future<void> _fetchRezultatiData() async {
    try {
      List<Rezultat> fetchedRezultatiList =
          await RezultatProvider().getAllRezultati();
      setState(() {
        rezultatiList = fetchedRezultatiList;
      });
    } catch (e) {
      print('Error fetching Rezultati data: $e');
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
    List<Rezultat> filteredRezultatiList = rezultatiList
        .where((rezultat) =>
            selectedKategorija == 'All' ||
            rezultat.projekat?.kategorijaId.toString() == selectedKategorija)
        .toList();
    return Scaffold(
      appBar: AppBar(
        title: Text('Rezultati'),
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
                DataColumn(label: Text('Projekat Naziv')),
                DataColumn(label: Text('Napomena')),
                DataColumn(label: Text('Bod')),
                DataColumn(label: Text('Projekat Opis')),
                DataColumn(label: Text('Kategorija ID')),
              ],
              rows: filteredRezultatiList.map((rezultat) {
                return DataRow(cells: [
                  DataCell(Text(rezultat.projekat?.naziv ?? '')),
                  DataCell(Text(rezultat.napomena)),
                  DataCell(Text(rezultat.bod.toString())),
                  DataCell(Text(rezultat.projekat?.opis ?? '')),
                  DataCell(Text(rezultat.projekat?.kategorijaId.toString() ?? '')),
                ]);
              }).toList(),
            ),
          ),
        ],
      ),
    );
  }
}
