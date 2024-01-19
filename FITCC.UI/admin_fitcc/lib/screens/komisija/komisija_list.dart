import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/komisija.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';
import 'package:admin_fitcc/providers/komisija_provider.dart';
import 'package:admin_fitcc/screens/komisija/komsija_add.dart';
import 'package:flutter/material.dart';

class KomisijaList extends StatefulWidget {
  @override
  _KomisijaListState createState() => _KomisijaListState();
}

class _KomisijaListState extends State<KomisijaList> {
  List<Komisija> komisijaList = [];
  List<Kategorija> kategorijeOptions = [];
  String selectedKategorija = 'All';
  Kategorija? latestKategorija;
  @override
  void initState() {
    super.initState();
    _fetchKomisijaData();
    _fetchKategorijeOptions();
  }

  Future<void> _fetchKomisijaData() async {
    try {
      List<Komisija> fetchedKomisijaList =
          await KomisijaProvider().fetchKomisijaList();
      setState(() {
        komisijaList = fetchedKomisijaList;
      });
    } catch (e) {
      print('Error fetching Komisija data: $e');
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
    List<Komisija> filteredKomisijaList = komisijaList
        .where((komisija) =>
            selectedKategorija == 'All' ||
            komisija.kategorijaID.toString() == selectedKategorija)
        .toList();
    return Scaffold(
      appBar: AppBar(
        title: Text('Komisija'),
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
                DataColumn(label: Text('Projekat Naziv')),
                DataColumn(label: Text('Napomena')),
                DataColumn(label: Text('Bod')),
                // DataColumn(label: Text('Projekat Opis')),
                // DataColumn(label: Text('Kategorija ID')),
              ],
              rows: filteredKomisijaList.map((rezultat) {
                return DataRow(cells: [
                  DataCell(Text(rezultat.ime)),
                  DataCell(Text(rezultat.prezime)),
                  DataCell(Text(rezultat.email.toString())),
                  // DataCell(Text(rezultat.ulogaKomisijeID'')),
                  // DataCell(Text(rezultat.projekat?.kategorijaId.toString() ?? '')),
                ]);
              }).toList(),
            ),
          ),
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => KomisijaAdd()),
          );
        },
        tooltip: 'Dodaj',
        child: Icon(Icons.add),
      ),
    );
  }

  void _deleteKomisija(int komisijaID) async {
    try {
      await KomisijaProvider().delete(komisijaID);
      _fetchKomisijaData(); // Refresh the list after deletion
    } catch (e) {
      print('Error deleting komisija: $e');
    }
  }

  void _editKomisija(Komisija komisija) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => KomisijaAdd(komisija: komisija)),
    );
  }
}
