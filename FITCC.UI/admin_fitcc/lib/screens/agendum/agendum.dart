import 'package:admin_fitcc/models/dogadjajagenda.dart';
import 'package:admin_fitcc/providers/dogadjaj_provider.dart';
import 'package:admin_fitcc/providers/dogadjajiperagenda_provider.dart';
import 'package:admin_fitcc/screens/agendum/dogadjaj_add.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class DogadjajList extends StatefulWidget {
  @override
  _DogadjajListState createState() => _DogadjajListState();
}

class _DogadjajListState extends State<DogadjajList> {
  List dogadjajList = [];

  @override
  void initState() {
    super.initState();
    _fetchDogadjajPerAgendaData();
  }

  Future<void> _fetchDogadjajPerAgendaData() async {
    try {
      List<DogadjajiPerAgenda> fetchedDogadjajList =
          await DogadjajPerAgendaProvider().fetchDogadjajperAgendaList();
      setState(() {
        dogadjajList = fetchedDogadjajList;
      });
    } catch (e) {
      print('Error fetching List data: $e');
    }
  }
 Future<void> _deleteDogadjaj(int dogadjajID) async {
    try {
          await DogadjajProvider().delete(dogadjajID);
    } catch (e) {
      print('Error deleting dogadjaj: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Dogadjaji'),
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Expanded(
            child: DataTable(
              columns: [
                DataColumn(label: Text('Dan')),
                DataColumn(label: Text('Naziv')),
                DataColumn(label: Text('Trajanje')),
                DataColumn(label: Text('Pocetak')),
                DataColumn(label: Text('Kraj')),
                DataColumn(label: Text('')),
                DataColumn(label: Text('')),
              ],
              rows: dogadjajList.map((dogadjaj) {
                return DataRow(cells: [
                  DataCell(Text(dogadjaj.dan.toString())),
                  DataCell(Text(dogadjaj.naziv)),
                  DataCell(Text(dogadjaj.trajanje.toString())),
                  DataCell(Text(_formatDate(dogadjaj.pocetak))),
                  DataCell(Text(_formatDate(dogadjaj.kraj))),
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        _editDogadjaj(dogadjaj);
                      },
                      child: Text('Uredi'),
                    ),
                  ),
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        _deleteDogadjaj(dogadjaj.dogadjajId); 
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
                MaterialPageRoute(builder: (context) => DogadjajAdd()),
              );
            },
            child: Text('Dodaj dogadjaj'),
          ),
        ],
      ),
    );
  }

  String _formatDate(DateTime? date) {
    if (date == null) {
      return '';
    }
    return DateFormat('dd-MM-yyyy').format(date);
  }

  void _editDogadjaj(DogadjajiPerAgenda dogadjaj) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => DogadjajAdd(dogadjaj: dogadjaj)),
    );
  }

}
