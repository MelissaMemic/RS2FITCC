import 'package:admin_fitcc/models/kriterij.dart';
import 'package:admin_fitcc/providers/kriterij_provider.dart';
import 'package:flutter/material.dart';
import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';

class KriterijAdd extends StatefulWidget {
    final Kriterij? kriterij;
  KriterijAdd({this.kriterij});

  @override
  _KriterijAddState createState() => _KriterijAddState();
}

class _KriterijAddState extends State<KriterijAdd> {
  TextEditingController nazivController = TextEditingController();
  TextEditingController vrijednostController = TextEditingController();
  String selectedKategorija = '1';

  List<Kategorija> kategorijeList = [];

  @override
  void initState() {
    super.initState();
    _fetchKategorijeList();
     if (widget.kriterij != null) {
      selectedKategorija = widget.kriterij!.kategorijaId.toString();
      nazivController.text = widget.kriterij!.naziv;
      vrijednostController.text = widget.kriterij!.vrijednost;
    }
  }

  Future<void> _fetchKategorijeList() async {
    try {
      List<Kategorija> fetchedKategorijeList =
          await KategorijaProvider().getKategorije();
      setState(() {
        kategorijeList = fetchedKategorijeList;
      });
    } catch (e) {
      print('Error fetching Kategorije data: $e');
    }
  }

  Future<void> _insertKriterij() async {
    try {
            if (widget.kriterij != null) {

       await KriterijProvider().update(widget.kriterij!.kriterijId, {
          widget.kriterij!.kriterijId,
          nazivController.text,
          vrijednostController.text,
          int.parse(selectedKategorija)
        });
            }else{
Kriterij insertObject=Kriterij();
insertObject.kriterijId=0;
        insertObject.naziv = nazivController.text;
      insertObject.vrijednost = vrijednostController.text;
      insertObject.kategorijaId = int.parse(selectedKategorija);
      insertObject.kategorija=Kategorija.full();
        await KriterijProvider().insert(insertObject);
        Navigator.pushNamed(context, '/homePage');
            }
    } catch (e) {
      print('Error inserting Kriterij data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Add Kriterij'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            TextField(
              controller: nazivController,
              decoration: InputDecoration(labelText: 'Naziv'),
            ),
            TextField(
              controller: vrijednostController,
              decoration: InputDecoration(labelText: 'Vrijednost'),
            ),
            DropdownButtonFormField<String>(
              value: selectedKategorija,
              onChanged: (value) {
                setState(() {
                  selectedKategorija = value!;
                });
              },
              items: kategorijeList.map((kategorija) {
                return DropdownMenuItem<String>(
                  value: kategorija.kategorijaId.toString(),
                  child: Text(kategorija.naziv.toString()),
                );
              }).toList(),
              decoration: InputDecoration(labelText: 'Kategorija'),
            ),
            SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                _insertKriterij();
              },
              child: Text('Dodaj Kriterij'),
            ),
          ],
        ),
      ),
    );
  }
}
