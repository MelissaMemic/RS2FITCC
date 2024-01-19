
import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/projekat.dart';
import 'package:mobile_fitcc/Models/rezultat.dart';
import 'package:mobile_fitcc/Providers/rezultat_provider.dart';

  class OcjenjivanjeProjektaScreen extends StatefulWidget {
   final Projekat? projekat;
  OcjenjivanjeProjektaScreen({this.projekat});

  @override
  _OcjenjivanjeProjektaScreenState createState() => _OcjenjivanjeProjektaScreenState();
}
class _OcjenjivanjeProjektaScreenState extends State<OcjenjivanjeProjektaScreen> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController inovacijeController = TextEditingController();
  final TextEditingController napomenaController = TextEditingController();
  TextEditingController _errorMessageController = TextEditingController();

  @override
  void dispose() {
    inovacijeController.dispose();
    napomenaController.dispose();
    super.dispose();
  }

  // void _submitForm() {
  //   if (_formKey.currentState!.validate()) {
  //     final resultat = RezultatInsert(
  //       int.parse(inovacijeController.text),
  //       napomenaController.text,
  //       widget.projekat!.projekatId
  //     );

  //     RezultatProvider().insert(resultat);
  //     Navigator.push(
  //       context,
  //       MaterialPageRoute(builder: (context) => PregledProjekataScreen()),
  //     );
  //   }
  // }
Future<void> _spasiOcjenu() async {
    {
      var rezultatService = RezultatProvider();
      Rezultat rezultat = Rezultat();
      rezultat.bod = int.parse(inovacijeController.text);
      rezultat.napomena = napomenaController.text;
      rezultat.projekatId=widget.projekat!.projekatId;
      var response = await rezultatService.insert(rezultat);

      if (response!.toJson() != null) {
        Navigator.pushNamed(context, '/pregledProjekataZiri');
      } else
        _errorMessageController.text = "Doslo je do greske";
    }
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Ocjenjivanje ${widget.projekat?.naziv}'), 
      ),
      body: Form(
        key: _formKey,
        child: SingleChildScrollView(
          padding: EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Text('Naziv projekta: ${widget.projekat?.naziv ?? 'N/A'}'),
              SizedBox(height: 20),
              TextFormField(
                controller: inovacijeController,
                decoration: InputDecoration(labelText: 'Inovacije'),
                keyboardType: TextInputType.number,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Ovo polje je obavezno';
                  }
                  if (int.tryParse(value) == null) {
                    return 'Unesite validan broj';
                  }
                  return null;
                },
              ),
              SizedBox(height: 10),
              TextFormField(
                controller: napomenaController,
                decoration: InputDecoration(labelText: 'Napomena'),
                maxLines: 3,
              ),
              SizedBox(height: 20),
              ElevatedButton(
                child: Text('Ocijeni'),

                onPressed:() {
                        if (_formKey.currentState!.validate()) {
                          _spasiOcjenu();
                        }}
              ),
            ],
          ),
        ),
      ),
    );
  }
}
