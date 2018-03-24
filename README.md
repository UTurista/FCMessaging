[![NuGet version](https://badge.fury.io/nu/FCMessaging.svg)](https://badge.fury.io/nu/FCMessaging)
[![Build Status](https://travis-ci.org/UTurista/FCMessaging.svg?branch=develop)](https://travis-ci.org/UTurista/FCMessaging)

# FCMessaging
C# Implementation of the new [HTTP v1 API protocol](https://firebase.google.com/docs/reference/fcm/rest/v1/projects.messages) of Firebase Cloud Messaging (FCM) which is:
>the most up to date, with more secure authorization and flexible cross-platform messaging capabilities

Note that if you want to use upstream messaging from your client applications, you must use XMPP



## Sending your first message

Before you send your first message you require a **credential file given by Firebase**:
  - In the Firebase console, open Settings > [Service Accounts](https://console.firebase.google.com/project/_/settings/serviceaccounts/adminsdk).
  - Click Generate New Private Key, and confirm by clicking Generate Key.
  - Download and save the file to a secure location


Once you have your server key and credentials, instatiate a client object with:
```c#
FCMClient client = new FCMClient("relative-path-to-credential-file");
```

Create a simle message and send it:
```c#
Message message = new Message
  .Builder()
  .ToTopic("news")
  .Title("my title")
  .Body("my body")
  .Build();

string id = await client.Send(message);
```

More details about FCM messages can be found in the product documentation at: 
- https://firebase.google.com/docs/cloud-messaging/concept-options
- https://firebase.google.com/docs/cloud-messaging/server?hl=en-us#implementing-http-connection-server-protocol

## Contributing

You know how to do it! Fork it, branch it, change it, commit it, and pull-request it. We are passionate about improving this project, and glad to accept help to make it better.
