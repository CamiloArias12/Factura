import 'dart:convert';

class Client {
  String id;
  String name;
  String email;

  Client({
    required this.id,
    required this.name,
    required this.email,
  });

  factory Client.fromJson(String json) => Client.fromMap(jsonDecode(json));

  String toJson() => jsonEncode(toMap());

  factory Client.fromMap(Map<String, dynamic> map) {
    return Client(
      id: map['id'],
      name: map['name'],
      email: map['email'],
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'name': name,
      'email': email,
    };
  }
}
