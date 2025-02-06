# Alarm Test 1

This app works on both Android and iOS. On the main page, there's a textfield and a button. When the button is clicked, it will schedule a notification based on the number on the textfield. For example, if the textfield has a number '5', the notification notification will be scheduled to appear after 5 seconds.

## Environment
I'm using .NET 8.0 for both Android and iOS (see AlarmTest2.csproj). I'm using an iPhone 16 simulator (iOS 18.2) and Google Pixel 4 simulator (API 34). 

### Note
- For iOS, the notification doesn't have sound. For Android, it does.
- For both iOS and Android, the scheduled notification will still be sent even if you press the home screen button. 
- If you quit the app, the scheduled notification will still be sent for iOS (but not for Android). This is because iOS and Android handle notifications differently. I'll try to get that fixed ASAP. 
