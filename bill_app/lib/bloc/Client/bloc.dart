import 'package:bill_app/bloc/Client/event.dart';
import 'package:bill_app/bloc/Client/state.dart';
import 'package:bill_app/domain/entities/client.dart';
import 'package:bill_app/services/client_service.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class ClientBloc extends Bloc<ClientEvent, ClientState> {
  late final AbstractClientService billService;

  ClientBloc() : super(ClientStartState()) {
    on<ClientFetchEvent>(_fetchAllClient);
  }

  Future<void> _fetchAllClient(ClientEvent event, Emitter emit) async {
    emit(ClientLoadingState());
    try {
      List<Client> bills = await billService.fetchAll();
      emit(ClientLoadedState(bills: bills));
    } catch (e) {
      print(e);
      emit(ClientErrorState());
    }
  }
}
