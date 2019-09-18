? kill bad psexec
+ remove chrome service Yoni_Chrome
+git change

minimal chefsharp + propietery + addSecret -> One url!!! (not tabbed)
+ anti proxy + on adress change + beforebrowse + timer per frame
build ? 75.1.14


**** START AS USER (both local) + SECURITY
**** GET SID from the same user you gonna run. and use dynamiclly. 
    + Save to log of txt file.
    
problems to doc:
    * just running chrome with deny all (process security) doesnt work (someone reading from child renderer processes?)
    * user A can see user B commands (when both not elevated)
    * can't elevate even if has password unless UAC dialog  (Possible only on service space)
    * can only run interactive as the logged on user (not elvated)
    * CreateProcessAsUserW (the only one with DACL input) can run only from service, so cant access desktop also not:
        ** service -> local (protected) [user,pass,secret] -> other user (protected against local (not agaist itself)) [secret]
    * Cant debug user B from user A (All thread data is denied, verfied with Process explorer)
        * Altough EXE \ Command \ ENV Block is allowed.
	* To open process as another user U must have QUERY_LIMITED_INFORMATION + QUERY_INFORMATION which show stuff!!! (and block debug??)
        So no (can't create process from proteted) : 
            (At leaser for limited user vs user who can be admin)

            service -> 
                -> named pipe onlt admin can use ----------------------------->
                -> protected local (against debug) [user,pas] -> CreateLogon -> Get pass from pipe

            https://docs.microsoft.com/en-us/windows/win32/ipc/named-pipes
            https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createnamedpipea
            
            
            1) File acceasible to USER B                                         ->       V
            2) Service -> USER A [user,pass] protected -> Open process as USER B -> Read from file.
  
solution:
    
    C&C -> Add active session -> PsExec -> Run Filtered chrome as User B + Interactive.
        (Probably run as user  + change session  + change user on token before CreateProcess)
    