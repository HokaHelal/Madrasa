import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChatMessage } from 'src/app/_models/ChatMessage';
import { PeerData } from 'src/app/_models/peerData';
import { SignalInfo } from 'src/app/_models/SignalInfo';
import { UserInfo } from 'src/app/_models/UserInfo';
import { RtcService } from 'src/app/_services/Rtc.service';
import { SignalrService } from 'src/app/_services/signalr.service';

@Component({
  selector: 'app-video-stream',
  templateUrl: './video-stream.component.html',
  styleUrls: ['./video-stream.component.scss']
})
export class VideoStreamComponent implements OnInit, OnDestroy {
  @Input() user: UserInfo;
  public messages: Array<ChatMessage>;
  public userVideo;
  private stream;

  public subscriptions = new Subscription();
  @ViewChild('videoStream', {static: true}) videoPlayer : ElementRef;

  constructor(private rtcService: RtcService, private signalR: SignalrService) { }

  ngOnInit() {
    console.log('video : ' + this.videoPlayer);

    this.subscriptions.add(this.signalR.signal$.subscribe((signalData: SignalInfo) => {
      console.log(`SignalR signal ${signalData.user}: ${signalData.signal}`);
      this.rtcService.signalPeer(signalData.user, signalData.signal, this.stream);
    }));

    this.subscriptions.add(this.rtcService.onSignalToSend$.subscribe((data: PeerData) => {
      console.log(`Signal to send ${data.connectionId}: ${data.stream}`);
      this.signalR.sendSignalToUser(data.stream, data.connectionId);
    }));

    this.subscriptions.add(this.rtcService.onData$.subscribe((data: PeerData) => {
      this.messages = [...this.messages, { own: false, message: data.stream }];
      console.log(`Data from user ${data.connectionId}: ${data.stream}`);
    }));
    
    this.subscriptions.add(this.rtcService.onStream$.subscribe((data: PeerData) => {
      this.userVideo = data.connectionId;
      this.videoPlayer.nativeElement.srcObject = data.stream;
      this.videoPlayer.nativeElement.load();
      this.videoPlayer.nativeElement.play();
    }));   
  }

  ngOnDestroy() {
    this.subscriptions.unsubscribe();
  }
}
