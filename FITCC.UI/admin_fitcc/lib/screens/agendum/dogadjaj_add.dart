import 'package:admin_fitcc/models/agenda.dart';
import 'package:admin_fitcc/models/dogadjaj.dart';
import 'package:admin_fitcc/models/dogadjajagenda.dart';
import 'package:admin_fitcc/providers/agenda_provider.dart';
import 'package:admin_fitcc/providers/dogadjaj_provider.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class DogadjajAdd extends StatefulWidget {
  final DogadjajiPerAgenda? dogadjaj;
  DogadjajAdd({this.dogadjaj});

  @override
  _DogadjajAddState createState() => _DogadjajAddState();
}

class _DogadjajAddState extends State<DogadjajAdd> {
  List<Agenda> agendaList = [];
  Agenda? selectedAgenda;
  Agenda? preselectedAgenda;

  TextEditingController nazivController = TextEditingController();
  TextEditingController lokacijaController = TextEditingController();
  TextEditingController pocetakController = TextEditingController();
  TextEditingController trajanjeController = TextEditingController();
  TextEditingController napomenaController = TextEditingController();
  TextEditingController krajController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _fetchAgendaList();
    if (widget.dogadjaj != null) {
      _getpreselectedAgenda(widget.dogadjaj!.agendaId);

      selectedAgenda = preselectedAgenda;
      nazivController.text = widget.dogadjaj!.naziv;
      lokacijaController.text = widget.dogadjaj!.lokacija;
      //napomenaController.text = widget.dogadjaj!.napomena;
      krajController.text = widget.dogadjaj!.pocetak != null
          ? _formatDate(widget.dogadjaj!.kraj!)
          : '';
      trajanjeController.text = widget.dogadjaj!.trajanje?.toString() ?? '';
      pocetakController.text = widget.dogadjaj!.pocetak != null
          ? _formatDate(widget.dogadjaj!.pocetak!)
          : '';
    }
  }

  Future<void> _getpreselectedAgenda(int id) async {
    try {
      Agenda fetchedAgenda = await AgendaProvider().getById(id);
      setState(() {
        preselectedAgenda = fetchedAgenda;
      });
    } catch (e) {
      print('Error fetching Agenda preselect: $e');
    }
  }

  Future<void> _fetchAgendaList() async {
    try {
      List<Agenda> fetchedAgendaList = await AgendaProvider().fetchAgendaList();
      setState(() {
        agendaList = fetchedAgendaList;
      });
    } catch (e) {
      print('Error fetching Agenda list: $e');
    }
  }

  Future<void> _insertDogadjaj() async {
    try {
      if (widget.dogadjaj != null) {
        await DogadjajProvider().update(widget.dogadjaj!.dogadjajId, {
          widget.dogadjaj!.dogadjajId,
          nazivController.text,
          int.parse(trajanjeController.text),
          _parseDate(pocetakController.text),
          _parseDate(krajController.text),
          ' ',
          1,
          'Tribina'
        });
      } else {
        Dogadjaj insertObject=Dogadjaj();
        insertObject.naziv = nazivController.text;
      insertObject.trajanje = int.parse(trajanjeController.text);
      insertObject.pocetak = _parseDate(pocetakController.text);
      insertObject.napomena = ' ';
      insertObject.agendaId = 1;
      insertObject.lokacija = lokacijaController.text;

        await DogadjajProvider().insert(insertObject);
      }
    } catch (e) {
      print('Error inserting/updating Dogadjaj data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.dogadjaj != null ? 'Edit Dogadjaj' : 'Add Dogadjaj'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            if (widget.dogadjaj != null)
              Text(
                'Dogadjaj ID: ${widget.dogadjaj!.dogadjajId}',
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
              ),
            TextField(
              controller: nazivController,
              decoration: InputDecoration(labelText: 'Naziv'),
            ),
            TextField(
              controller: lokacijaController,
              decoration: InputDecoration(labelText: 'Lokacija'),
            ),
            TextField(
              controller: trajanjeController,
              decoration: InputDecoration(labelText: 'Trajanje'),
            ),
            TextField(
              controller: pocetakController,
              decoration: InputDecoration(labelText: 'Pocetak'),
            ),
            TextField(
              controller: krajController,
              decoration: InputDecoration(labelText: 'Kraj'),
            ),
            SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                _insertDogadjaj();
              },
              child: Text('Dodaj Dogadjaj'),
            ),
          ],
        ),
      ),
    );
  }

  DateTime _parseDate(String dateString) {
    try {
      return DateFormat('dd-MM-yyyy').parse(dateString);
    } catch (e) {
      print('Error parsing date: $e');
      throw Exception('Invalid date format');
    }
  }

  String _formatDate(DateTime date) {
    return DateFormat('dd-MM-yyyy').format(date);
  }
}
