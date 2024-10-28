import 'package:bill_app/bloc/Bill/bloc.dart';
import 'package:bill_app/bloc/Bill/event.dart';
import 'package:bill_app/bloc/Bill/state.dart';
import 'package:bill_app/bloc/Client/bloc.dart';
import 'package:bill_app/bloc/Client/event.dart';
import 'package:bill_app/bloc/Client/state.dart';
import 'package:bill_app/ui/widgets/table_bill.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';

class BillPage extends StatefulWidget {
  late final BillBloc billBloc;
  late final ClientBloc clientBloc;

  BillPage({super.key}) {
    clientBloc = GetIt.I.get<ClientBloc>();
    billBloc = GetIt.I.get<BillBloc>();
  }

  @override
  State<StatefulWidget> createState() => _BillPage();
}

class _BillPage extends State<BillPage> {
  @override
  void initState() {
    widget.billBloc.add(BillFetchEvent());
    widget.clientBloc.add(ClientFetchEvent());
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: const Text('Facturas')),
        body: Padding(
          padding: const EdgeInsets.all(8.0),
          child: BlocBuilder<BillBloc, BillState>(builder: (context, state) {
            if (state is! BillLoadedState) {
              return const Text("loadin");
            }
            return BlocBuilder<ClientBloc, ClientState>(
                builder: (context, stateClient) {
              if (state is! ClientLoadedState) {
                return const Text("loadin");
              }
              return BillTable(bills: state.bills);
            });
          }),
        ));
  }
}
