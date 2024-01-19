class Projekat {
  final int projekatId;
  final String naziv;
  final String opis;
  final int kategorijaId;
  final int timId;
  final int userId;
  final String username;
  final dynamic kategorija; // You can update this to the actual data type if needed
  final dynamic tim; // You can update this to the actual data type if needed

  Projekat({
    required this.projekatId,
    required this.naziv,
    required this.opis,
    required this.kategorijaId,
    required this.timId,
    required this.userId,
    required this.username,
    required this.kategorija,
    required this.tim,
  });

  factory Projekat.fromJson(Map<String, dynamic> json) {
    return Projekat(
      projekatId: json['projekatId'] as int,
      naziv: json['naziv'] as String,
      opis: json['opis'] as String,
      kategorijaId: json['kategorijaId'] as int,
      timId: json['timId'] as int,
      userId: json['userId'] as int,
      username: json['username'] as String,
      kategorija: json['kategorija'],
      tim: json['tim'],
    );
  }
}
