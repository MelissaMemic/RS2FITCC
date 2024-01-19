import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/dogadjajagenda.dart';
import 'package:mobile_fitcc/Providers/dogadjajiperagenda_provider.dart';
import 'package:intl/intl.dart';

class PregledAgendaScreen extends StatefulWidget {
  @override
  _PregledAgendaScreenState createState() => _PregledAgendaScreenState();
}

class _PregledAgendaScreenState extends State<PregledAgendaScreen> {
  List<DogadjajiPerAgenda> dogadjaji = [];

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
        dogadjaji = fetchedDogadjajList;
      });
    } catch (e) {
      print('Error fetching List data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    Map<String, List<DogadjajiPerAgenda>> groupedEvents = {};
    for (var dogadjaj in dogadjaji) {
      groupedEvents.putIfAbsent(dogadjaj.dan.toString(), () => []);
      groupedEvents[dogadjaj.dan.toString()]?.add(dogadjaj);
    }
    List<Widget> _buildExpansionTiles() {
      List<Widget> tiles = [];

      Widget header = Container(
        padding: EdgeInsets.symmetric(vertical: 8.0, horizontal: 16.0),
        color: Colors.grey[300],
        child: Row(
          children: [
            Expanded(flex: 3, child: Text('Naziv')),
            Expanded(flex: 2, child: Text('Pocetak')),
            Expanded(flex: 2, child: Text('Kraj')),
            Expanded(flex: 3, child: Text('Lokacija')),
          ],
        ),
      );
      tiles.add(header);

      groupedEvents.forEach((day, events) {
        tiles.add(
          ExpansionTile(
            title: Text('Dan $day'),
            children: events.map((event) {
              String formattedTimepocetak =
                  DateFormat('HH:mm').format(event.pocetak!);
              String formattedTimekraj =
                  DateFormat('HH:mm').format(event.kraj!);
              return Container(
                decoration: BoxDecoration(
                  border: Border.all(color: Colors.grey),
                ),
                child: Row(
                  children: [
                    Expanded(
                      flex: 3,
                      child: Container(
                        padding: EdgeInsets.all(8.0),
                        child: Text(event.naziv),
                        decoration: BoxDecoration(
                          border: Border(right: BorderSide(color: Colors.grey)),
                        ),
                      ),
                    ),
                    Expanded(
                      flex: 2,
                      child: Container(
                        padding: EdgeInsets.all(8.0),
                        child: Text(formattedTimepocetak),
                        decoration: BoxDecoration(
                          border: Border(right: BorderSide(color: Colors.grey)),
                        ),
                      ),
                    ),
                    Expanded(
                      flex: 2,
                      child: Container(
                        padding: EdgeInsets.all(8.0),
                        child: Text(formattedTimekraj),
                        decoration: BoxDecoration(
                          border: Border(right: BorderSide(color: Colors.grey)),
                        ),
                      ),
                    ),
                    Expanded(
                      flex: 3,
                      child: Container(
                        padding: EdgeInsets.all(8.0),
                        child: Text(event.lokacija),
                      ),
                    ),
                  ],
                ),
              );
            }).toList(),
          ),
        );
      });

      return tiles;
    }

    return Scaffold(
  
  body: SingleChildScrollView(
    child: Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: _buildExpansionTiles(),
    ),
  ),
);

  }
}
