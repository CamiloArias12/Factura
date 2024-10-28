import 'package:bill_app/domain/entities/bill.dart';
import 'package:flutter/material.dart';

class BillTable extends StatelessWidget {
  final List<Bill> bills;

  const BillTable({super.key, required this.bills});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: DataTable(
        columns: const [
          DataColumn(label: Text('Bill Code')),
          DataColumn(label: Text('Total')),
          DataColumn(label: Text('Subtotal')),
          DataColumn(label: Text('VAT')),
          DataColumn(label: Text('Withholding')),
          DataColumn(label: Text('Creation Date')),
          DataColumn(label: Text('Status')),
          DataColumn(label: Text('City')),
          DataColumn(label: Text('Paid')),
          DataColumn(label: Text('Payment Date')),
          DataColumn(label: Text('Client ID')),
        ],
        rows: bills.map((bill) {
          return DataRow(cells: [
            DataCell(Text(bill.billCode)),
            DataCell(Text(bill.billTotal?.toStringAsFixed(2) ?? 'N/A')),
            DataCell(Text(bill.subtotal?.toStringAsFixed(2) ?? 'N/A')),
            DataCell(Text(bill.vat?.toStringAsFixed(2) ?? 'N/A')),
            DataCell(Text(bill.withholding?.toStringAsFixed(2) ?? 'N/A')),
            DataCell(
                Text(bill.creationDate.toIso8601String().split('T').first)),
            DataCell(Text(bill.status ?? 'N/A')),
            DataCell(Text(bill.city ?? 'N/A')),
            DataCell(Text(bill.isPaid == true ? 'Yes' : 'No')),
            DataCell(Text(
                bill.paymentDate?.toIso8601String().split('T').first ?? 'N/A')),
            DataCell(Text(bill.clientId ?? 'N/A')),
          ]);
        }).toList(),
      ),
    );
  }
}
