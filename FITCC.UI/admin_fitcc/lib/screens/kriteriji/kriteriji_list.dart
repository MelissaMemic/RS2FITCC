import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/kriterij.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';
import 'package:admin_fitcc/providers/kriterij_provider.dart';
import 'package:admin_fitcc/screens/kriteriji/kriterij_add.dart';
import 'package:flutter/material.dart';

class KriterijiList extends StatefulWidget {
  @override
  _KriterijiListState createState() => _KriterijiListState();
}

class _KriterijiListState extends State<KriterijiList> {
  List<Kriterij> kriterijiList = [];
  List<Kategorija> kategorijeOptions = [];
  String selectedKategorija = 'All';

  @override
  void initState() {
    super.initState();
    _fetchKriterijData();
    _fetchKategorijeOptions();
  }

  Future<void> _fetchKriterijData() async {
    try {
      List<Kriterij> fetchedKriterijiList =
          await KriterijProvider().get();
      setState(() {
        kriterijiList = fetchedKriterijiList;
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
    List<Kriterij> filteredKriterijiList = kriterijiList
        .where((kriterij) =>
            selectedKategorija == 'All' ||
            kriterij.kategorijaId.toString() == selectedKategorija)
        .toList();

    return Scaffold(
      appBar: AppBar(
        title: Text('Kriteriji'),
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
                DataColumn(label: Text('Naziv')),
                DataColumn(label: Text('Vrijednost')),
                DataColumn(label: Text('')),
                DataColumn(label: Text('')),
              ],
              rows: filteredKriterijiList.map((kriterij) {
                return DataRow(cells: [
                  DataCell(Text(kriterij.naziv)),
                  DataCell(Text(kriterij.vrijednost)),
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        _editKriterij(kriterij);
                      },
                      child: Text('Uredi'),
                    ),
                  ),
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        _deleteKriterij(kriterij.kriterijId); 
                      },
                      style: ElevatedButton.styleFrom(primary: Colors.red),
                      child: Text('Izbrisi'),
                    ),
                  ),
                ]);
              }).toList(),
            ),
          ),
       ElevatedButton(
            onPressed: () {
              Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => KriterijAdd()),
              );
            },
            child: Text('Dodaj kriterij'),
          ),
        ],
      ),
    );
  }
 Future<void> _deleteKriterij(int kriterijId) async {
    try {
          await KriterijProvider().delete(kriterijId);
    } catch (e) {
      print('Error deleting kriterij: $e');
    }
  }
  void _editKriterij(Kriterij kriterij) {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => KriterijAdd(kriterij: kriterij),
      ),
    );
  }
}
