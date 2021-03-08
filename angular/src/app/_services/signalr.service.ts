import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject, Subject } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PeerData } from '../_models/peerData';
import { SignalInfo } from '../_models/SignalInfo';
import { UserInfo } from '../_models/UserInfo';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

private hubConnection: HubConnection;

private newPeer = new Subject<UserInfo>();
public newPeer$ = this.newPeer.asObservable();

private peerData = new Subject<PeerData>();
public peerData$ = this.peerData.asObservable();

private onlineUsersSource = new BehaviorSubject<UserInfo[]>([]);
public onlineUsers$ = this.onlineUsersSource.asObservable();

private helloAnswer = new Subject<UserInfo>();
public helloAnswer$ = this.helloAnswer.asObservable();

private disconnectedPeer = new Subject<string>();
public disconnectedPeer$ = this.disconnectedPeer.asObservable();

private myConnectionId = new Subject<string>();
public myConnectionId$ = this.myConnectionId.asObservable();

private signal = new Subject<SignalInfo>();
public signal$ = this.signal.asObservable();

constructor() { }

public async startConnection(currentUser: UserInfo, userToken: string): Promise<void> {

  this.hubConnection = new HubConnectionBuilder()
    .withUrl(environment.hubUrl + 'classroom', {
      accessTokenFactory: () => userToken
    }).withAutomaticReconnect().build();

  await this.hubConnection.start();

  this.hubConnection.on('NewUserArrived', (username: UserInfo) => {
    this.onlineUsers$.pipe(take(1)).subscribe(usernames => {
      this.onlineUsersSource.next([...usernames, username]);
    });
    this.newPeer.next(username);
  });

  this.hubConnection.on("GetOnlineUsers", (usernames: UserInfo[]) => {
    this.onlineUsersSource.next(usernames);
  });

  this.hubConnection.on('Stream', (peerData: PeerData) => {
    this.peerData.next(peerData);
  });

  this.hubConnection.on('UserSaidHello', (data) => {
    this.helloAnswer.next(JSON.parse(data));
  });

  this.hubConnection.on('UserDisconnect', (username, connectionId) => {
    this.onlineUsers$.pipe(take(1)).subscribe(usernames => {
      this.onlineUsersSource.next(usernames.filter(x=>x.username != username && x.connectionId != connectionId));
    });
    this.disconnectedPeer.next(username);
  });

  this.hubConnection.on('SendSignal', (user, signal) => {
    this.signal.next({ user, signal });
  });

  this.hubConnection.on('GetMyConnectionId', (connectionId) => {
    this.myConnectionId.next(connectionId);
  });

  this.hubConnection.invoke('NewUser', currentUser);
}

public sendStream(peerData: PeerData) {
  this.hubConnection.invoke('Stream', peerData);
}

public sendSignalToUser(signal: string, user: string) {
  this.hubConnection.invoke('SendSignal', signal, user);
}

public sayHello(userName: string, user: string): void {
  this.hubConnection.invoke('HelloUser', userName, user);
}

stopHubConnection() {
  this.hubConnection?.stop();
}
}
