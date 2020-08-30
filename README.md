# Spotify.NetStandard.Sdk

Spotify API .NET Standard SDK Library

## Change Log

### Version 1.0.0

- Initial Release

## ActionsResponse

Actions Response

### Allows

Update the user interface based on which playback actions are allowed within the current context

### Disallows

Update the user interface based on which playback actions are disallowed within the current context


## AddPlaylistItemRequest

Add Playlist Item Request

### Id

Spotify Track or Episode Id

### PlayItemType

Track or Episode


## AddPlaylistRequest

Add Playlist Request

### UserId

(Required) Spotify User Id


## AlbumResponse

Album Response

### AddedAt

AlbumType.UserSaved Only - The date and time the album was saved Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ. If the time is imprecise (for example, the date/time of an album release), an additional field indicates the precision; see for example, ReleaseDate in an album object

### AddUserPlaybackCommand

Start/Resume a User's Playback

### AlbumGroup

The field is present when getting an artist’s albums. Possible values are “album”, “single”, “compilation”, “appears_on”

### AlbumType

The type of the album: one of "album", "single", or "compilation"

### Artist

Artist Response

### Artists

The artists of the album. Each artist response includes a link in href to more detailed information about the artist

### AvailableMarkets

The markets in which the album is available: ISO 3166-1 alpha-2 country codes

### Copyrights

The copyright statements of the album.

### ExternalId

Known external IDs for the album.

### Genres

A list of the genres used to classify the album. For example: "Prog Rock", "Post-Grunge"

### Images

The cover art for the album in various sizes, widest first

### Label

The label for the album.

### Large

Large Image

### Medium

Medium Image

### PlaybackStartType

Playback Start Type

### Popularity

The popularity of the album. The value will be between 0 and 100, with 100 being the most popular

### ReleaseDate

The date the album was first released, for example 1981. Depending on the precision, it might be shown as 1981-12 or 1981-12-15

### ReleaseDatePrecision

The precision with which ReleaseDate value is known: year, month, or day.

### ReleaseDateYear

Release Date Year

### Small

Small Image

### ToggleFavourite

Toggle Favourite Album

### ToggleSaved

Toggle User's Saved Album

### TotalTracks

The total number of tracks

### Tracks

The tracks of the album


## AlbumsRequest

Albums Request

### AlbumType

Album Type

### Country

(Optional) Only for AlbumType.Search, AlbumType.NewReleases, AlbumType.Artist and AlbumType.UserSaved - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### IncludeGroup

(Optional) Only used for AlbumType.Artist - Filters the response. If not supplied, all album types will be returned

### MultipleAlbumIds

(Required) Only for AlbumType.Multiple - Multiple Spotify Album Ids

### SearchIsExternal

(Optional) Only for AlbumType.Search - If true the response will include any relevant audio content that is hosted externally

### Value

(Required) Only for AlbumType.Search - Album Search Term and AlbumType.Artist - Artist Id


## AlbumType

Album Type

### Artist

Artist Albums

### Favourite

Favourite Albums

### Multiple

Multiple Albums

### NewReleases

New Releases

### Search

Search for Albums

### UserSaved

User's Saved Albums


## AllowsResponse

Allows Response

### IsInterruptingPlaybackAllowed

Interrupting playback allowed?

### IsPausingAllowed

Pausing allowed?

### IsResumingAllowed

Resuming allowed?

### IsSeekingAllowed

Seeking allowed? Will be set to false while playing an ad track

### IsSkippingNextAllowed

Skipping next allowed? Will be set to false while playing an ad track

### IsSkippingPrevAllowed

Skipping previous allowed? Will be set to false while playing an ad track

### IsTogglingRepeatAllowed

Toggling repeat allowed?

### IsTogglingRepeatContextAllowed

Toggling repeat context allowed?

### IsTogglingRepeatTrackAllowed

Toggling repeat track allowed?

### IsTogglingShuffleAllowed

Toggling shuffle allowed?

### IsTransferringPlaybackAllowed

Transferring playback allowed?


## ArtistResponse

Artist Response

### AddUserPlaybackCommand

Start/Resume a User's Playback

### Followers

Information about the followers of the artist

### Genres

A list of the genres the artist is associated with. For example: "Prog Rock", "Post-Grunge"

### Images

Images of the artist in various sizes, widest first

### Large

Large Image

### Medium

Medium Image

### PlaybackStartType

Playback Start Type

### Popularity

The popularity of the artist. The value will be between 0 and 100, with 100 being the most popular

### Small

Small Image

### ToggleFavourite

Toggle Favourite Artist

### ToggleFollow

Toggle Following State for Artist

### TotalFollowers

The total number of followers.


## ArtistsRequest

Artists Request

### ArtistType

(Required) Artist Type

### Country

(Optional) Only for ArtistType.Search - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### MultipleArtistIds

(Required) Only for ArtistType.Multiple - Multiple Artist Spotify Ids

### SearchIsExternal

(Optional) Only for ArtistType.Search - If true the response will include any relevant audio content that is hosted externally.

### UserTopTimeRangeType

(Optional) Only for ArtistType.UserTop - Long Term: calculated from several years of data and including all new data as it becomes available, Medium Term: (Default) approximately last 6 months, Short Term: approximately last 4 weeks

### Value

(Required) Only for ArtistType.Search - Artist Search Term and ArtistType.Related - Artist Id


## ArtistType

Artist Type

### Favourite

Favourite Artists

### Multiple

Multiple Artists

### Related

Related Artists

### Search

Search for Artists

### UserFollowed

User's Followed Artists

### UserTop

User's Top Artists


## AudioAnalysisResponse

Audio Analysis Response

### Bars

The time intervals of the bars throughout the track

### Beats

The time intervals of beats throughout the track

### Sections

Sections are defined by large variations in rhythm or timbre, e.g.chorus, verse, bridge, guitar solo, etc

### Segments

Audio segments attempts to subdivide a song into many segments, with each segment containing a roughly consitent sound throughout its duration

### Tatums

A tatum represents the lowest regular pulse train that a listener intuitively infers from the timing of perceived musical events


## AudioFeaturesRequest

Audio Features Request

### MultipleTrackIds

(Required) Multiple Track Spotify Ids


## AudioFeaturesResponse

Audio Features Response

### Acousticness

A confidence measure from 0.0 to 1.0 of whether the track is acoustic

### AcousticPercentage

A confidence percentage from 0% to 100% of whether the track is acoustic

### AnalysisUrl

An HTTP URL to access the full audio analysis of this track

### Danceability

Danceability describes how suitable a track is for dancing based on a combination of musical elements including tempo, rhythm stability, beat strength, and overall regularity. A value of 0.0 is least danceable and 1.0 is most danceable

### DanceablePercentage

Danceability percentage described how suitable a track is for dancing based on a combination of musical elements including tempo, rhythm stability, beat strength, and overall regularity. A value of 0 is least danceable and 100% is most danceable

### Duration

The duration of the track in milliseconds

### Energy

Energy is a measure from 0.0 to 1.0 and represents a perceptual measure of intensity and activity

### EnergyPercentage

Energy percentage from 0% to 100% represents a perceptual measure of intensity and activity

### Instrumentalness

Predicts whether a track contains no vocals. “Ooh” and “aah” sounds are treated as instrumental in this context. Rap or spoken word tracks are clearly “vocal”. The closer the instrumentalness value is to 1.0, the greater likelihood the track contains no vocal content. Values above 0.5 are intended to represent instrumental tracks, but confidence is higher as the value approaches 1.0

### InstrumentalPercentage

Instrumental precentage predicts whether a track contains no vocals. “Ooh” and “aah” sounds are treated as instrumental in this context. Rap or spoken word tracks are clearly “vocal”. The closer the instrumentalness value is to 100%, the greater likelihood the track contains no vocal content. Values above 50% are intended to represent instrumental tracks, but confidence is higher as the value approaches 100%

### Key

The key the track is in. Integers map to pitches using standard Pitch Class notation.

### KeyString

The key the track is in using standard Pitch Class notation of C, C♯, D, D♯, E, F, F♯, G, G♯, A, A♯ or B

### Liveness

Detects the presence of an audience in the recording. Higher liveness values represent an increased probability that the track was performed live. A value above 0.8 provides strong likelihood that the track is live

### LivePercentage

Live precentage detects the presence of an audience in the recording. Higher liveness percentage represent an increased probability that the track was performed live. A value above 80% provides strong likelihood that the track is live

### Loudness

The overall loudness of a track in decibels (dB). Loudness values are averaged across the entire track and are useful for comparing relative loudness of tracks. Loudness is the quality of a sound that is the primary psychological correlate of physical strength (amplitude). Values typical range between -60 and 0 db

### LoudnessValue

The overall rounded loudness of a track in decibels (dB). Loudness values are averaged across the entire track and are useful for comparing relative loudness of tracks. Loudness is the quality of a sound that is the primary psychological correlate of physical strength (amplitude). Values typical range between -60 and 0 db

### MeterString

Meter is the estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure) of 3/4, 4/4, 5/4, 6/4 and 7/4

### Mode

Mode indicates the modality(major or minor) of a track, the type of scale from which its melodic content is derived. Major is represented by 1 and minor is 0

### ModeString

Mode indicates the modality of a track, the type of scale from which its melodic content is derived of which can be Major, Minor or none

### Speechiness

Speechiness detects the presence of spoken words in a track. The more exclusively speech-like the recording (e.g. talk show, audio book, poetry), the closer to 1.0 the attribute value. Values above 0.66 describe tracks that are probably made entirely of spoken words. Values between 0.33 and 0.66 describe tracks that may contain both music and speech, either in sections or layered, including such cases as rap music. Values below 0.33 most likely represent music and other non-speech-like tracks

### SpeechPercentage

Speechiness percentage detects the presence of spoken words in a track. The more exclusively speech-like the recording (e.g. talk show, audio book, poetry), the closer to 100% the attribute value. Values above 60% percent describe tracks that are probably made entirely of spoken words. Values between 33% and 66% describe tracks that may contain both music and speech, either in sections or layered, including such cases as rap music. Values below 33% most likely represent music and other non-speech-like tracks

### Tempo

The overall estimated tempo of a track in beats per minute (BPM). In musical terminology, tempo is the speed or pace of a given piece and derives directly from the average beat duration

### TempoValue

The overall estimated rounded tempo of a track in beats per minute (BPM). In musical terminology, tempo is the speed or pace of a given piece and derives directly from the average beat duration

### TimeSignature

An estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure)

### TrackHref

A link to the Web API endpoint providing full details of the track

### Valence

A measure from 0.0 to 1.0 describing the musical positiveness conveyed by a track. Tracks with high valence sound more positive (e.g. happy, cheerful, euphoric), while tracks with low valence sound more negative (e.g. sad, depressed, angry)

### ValencePercentage

Valence percentage from 0% to 100% describing the musical positiveness conveyed by a track. Tracks with high valence sound more positive (e.g. happy, cheerful, euphoric), while tracks with low valence sound more negative (e.g. sad, depressed, angry)


## AuthenticationAccessCodeNotFoundException

Authentication Access Code Not Found Exception

### Constructor(message, ex)

Constructor

| Name | Description |
| ---- | ----------- |
| message | *System.String*<br>Message |
| ex | *System.Exception*<br>Inner Exception |


## AuthenticationAccessTokenNotFoundException

Authentication Access Token Not Found Exception

### Constructor(message, ex)

Constructor

| Name | Description |
| ---- | ----------- |
| message | *System.String*<br>Message |
| ex | *System.Exception*<br>Inner Exception |


## AuthenticationFlowType

Authentication Flow Type

### AuthorisationCode

Authorisation Code Flow

### AuthorisationCodeWithProofKeyForCodeExchange

Authorization Code Flow With Proof Key For Code Exchange (PKCE)

### ClientCredentials

Client Credentials Flow

### ImplicitGrant

Implicit Grant Flow


## AuthenticationScopeRequest

Authentication Scope Request

### AllPermissions

Returns a new AuthorisationScopeRequest object with all scopes set to true Usage : AuthorisationScopeRequest.AllPermissions

### ConnectModifyPlaybackState

Pause a User's Playback 
Required For

Seek To Position In Currently Playing Track, Set Repeat Mode On User’s Playback, Set Volume For User's Playback

Skip User’s Playback To Next Track, Skip User’s Playback To Previous Track, Start/Resume a User's Playback

Toggle Shuffle For User’s Playback Transfer a User's Playback


### ConnectReadCurrentlyPlaying

Read access to a user’s currently playing track 
Required For

Get the User's Currently Playing Track


### ConnectReadPlaybackState

Read access to a user’s player state. 
Required For

Get a User's Available Devices, Get Information About The User's Current Playback, Get the User's Currently Playing Track


### FollowAll

Returns a new AuthorisationScopeRequest object with all scopes within the confines of Users set to true Usage : AuthorisationScopeRequest.FollowAll

### FollowModify

Write/delete access to the list of artists and other users that the user follows. 
Required For

Follow Artists or Users, Unfollow Artists or Users


### FollowRead

Read access to the list of artists and other users that the user follows. 
Required For

Check if Current User Follows Artists or Users, Get User's Followed Artists


### ImageUserGeneratedContentUpload

Write access to user-provided images 
Required For

Upload a Custom Playlist Cover Image


### LibraryAll

Returns a new AuthorisationScopeRequest object with all scopes within the confines of Library set to true Usage : AuthorisationScopeRequest.LibraryAll

### LibraryModify

Write/delete access to a user's "Your Music" library. 
Required For

Remove Albums for Current User, Remove User's Saved Tracks, Save Albums for Current User Save Tracks for User


### LibraryRead

Read access to a user's "Your Music" library. 
Required For

Check User's Saved Albums Check User's Saved Tracks, Get Current User's Saved Albums Get a User's Saved Tracks


### ListeningHistoryAll

Returns a new AuthorisationScopeRequest object with all scopes within the confines of Listening History set to true Usage : AuthorisationScopeRequest.ListeningHistoryAll

### ListeningRecentlyPlayed

Read access to a user’s recently played tracks 
Required For

Get Current User's Recently Played Tracks


### ListeningTopRead

Read access to a user's top artists and tracks. 
Required For

Get a User's Top Artists and Tracks


### ModifyAllAccess

Returns a new AuthorisationScopeRequest object with all "modify" scopes set to true Usage : AuthorisationScopeRequest.ModifyAllAccess

### PlaybackAll

Returns a new AuthorisationScopeRequest object with all scopes within the confines of Playback set to true Usage : AuthorisationScopeRequest.PlaybackAll

### PlaybackAppRemoteControl

Remote control playback of Spotify.

### PlaybackPositionRead

Read access to a user’s playback position in a content 
Optional For

Get an Episodes, Get Multiple Episodes, Get a Show, Get Multiple Shows, Get a Show's Episodes


### PlaybackStreaming

Control playback of a Spotify track. The user must have a Spotify Premium account.

### PlaylistAll

Returns a new AuthorisationScopeRequest object with all scopes within the confines of Playlists set to true Usage : AuthorisationScopeRequest.PlaylistAll

### PlaylistModifyPrivate

Write access to a user's private playlists. 
Required For

Follow a Playlist, Unfollow a Playlist, Add Tracks to a Playlist

Change a Playlist's Details, Create a Playlist, Remove Tracks from a Playlist

Reorder a Playlist's Tracks, Replace a Playlist's Tracks, Upload a Custom Playlist Cover Image


### PlaylistModifyPublic

Write access to a user's public playlists. 
Required For

Follow a Playlist, Unfollow a Playlist, Add Tracks to a Playlist

Change a Playlist's Details, Create a Playlist, Remove Tracks from a Playlist

Reorder a Playlist's Tracks, Replace a Playlist's Tracks, Upload a Custom Playlist Cover Image


### PlaylistReadCollaborative

Include collaborative playlists when requesting a user's playlists. 
Required For

Get a List of Current User's Playlists, Get a List of a User's Playlists


### PlaylistReadPrivate

Read access to user's private playlists. 
Required For

Check if Users Follow a Playlist, Get a List of Current User's Playlists, Get a List of a User's Playlists


### ReadAllAccess

Returns a new AuthorisationScopeRequest object with all "read" scopes set to true Usage : AuthorisationScopeRequest.ReadAllAccess

### SpotifyConnectAll

Returns a new AuthorisationScopeRequest object with all scopes within the confines of Spotify Connect set to true Usage : AuthorisationScopeRequest.SpotifyConnectAll

### UserReadEmail

Read access to user’s email address. 
Required For

Get Current User's Profile


### UserReadPrivate

Read access to user’s subscription details (type of user account). 
Required For

Search for an Item, Get Current User's Profile


### UsersAll

Returns a new AuthorisationScopeRequest object with all scopes within the confines of Users set to true Usage : AuthorisationScopeRequest.UsersAll


## AuthenticationStateNotMatchedException

Authentication State Not Matched Exception

### Constructor(message, ex)

Constructor

| Name | Description |
| ---- | ----------- |
| message | *System.String*<br>Message |
| ex | *System.Exception*<br>Inner Exception |


## AuthenticationTokenRequiredArgs

Token Required Arguments

### Constructor(tokenType)

Constructor

| Name | Description |
| ---- | ----------- |
| tokenType | *Spotify.NetStandard.Sdk.AuthenticationTokenType*<br>Token Type |

### TokenType

Token Type


## AuthenticationTokenRequiredException

Authentication Token Required Exception

### Constructor(tokenType)

Constructor

| Name | Description |
| ---- | ----------- |
| tokenType | *Spotify.NetStandard.Sdk.AuthenticationTokenType*<br>Token Type |

### TokenType

Token Type


## AuthenticationTokenResponse

Authentication Token Response

### AuthenticationTokenType

Authentication Token Type

### Error

Error

### Expiration

Token Expiration Date

### IsLoggedIn

Is Logged In

### IsValid

Is Valid

### Refresh

Refresh

### Scopes

Scopes

### Token

Access Token


## AuthenticationTokenType

Authentication Token Type

### Access

Access Token

### User

User Token

## BoolResponse

Bool Response

### Value

Response Value


## CategoriesRequest

Categories Request

### Country

(Optional) Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### Locale

(Optional) Overrides Client Locale as ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB


## CategoryResponse

Category Response

### Images

The category icon, in various sizes

### Large

Large Image

### Medium

Medium Image

### Small

Small Image


## ClientExceptionArgs

Client Exception Arguments

### Constructor(exception)

Constructor

| Name | Description |
| ---- | ----------- |
| exception | *System.Exception*<br>Exception |

### Exception

Exception


## CommandActions

Command Actions

### AddPlaylistItem

Add Playlist Item Command Action

### Album

Album Command Action

### Artist

Artist Command Action

### Category

Category Command Action

### CurrentlyPlaying

Currently Playing Command Action

### CurrentUser

Current User Command Action

### Episode

Episode Command Action

### GetAudioAnalysis

Get Audio Analysis Command Action

### GetAudioFeatures

Get Audio Features Command Action

### GetPlaylistImage

Get Playlist Image Command Action

### Playlist

Playlist Command Action

### RecommendationGenre

Recommendation Genre Command Action

### RemovePlaylistItem

Remove Playlist Item Command Action

### SetPlaylist

Change a Playlist's Details Command Action

### SetPlaylistImage

Upload a Custom Playlist Cover Image Command Action

### Show

Show Command Action

### Track

Track Command Action

### User

User Command Action


## Configuration

Configuration

### IsAttachGetAlbumCommands

Attach Get Album Commands?

### IsAttachGetAlbumToggles

Attach Get Album Toggles

### IsAttachGetArtistCommands

Attach Get Artist Commands?

### IsAttachGetArtistToggles

Attach Get Artist Toggles

### IsAttachGetCategoryCommands

Attach Get Category Commands?

### IsAttachGetCurrentUserCommands

Attach Get Current User Commands?

### IsAttachGetEpisodeCommands

Attach Get Episode Commands?

### IsAttachGetEpisodeToggles

Attach Get Episode Toggles

### IsAttachGetPlaylistCommands

Attach Get Playlist Commands?

### IsAttachGetPlaylistImageCommands

Attach Get Playlist Image Commands?

### IsAttachGetPlaylistToggles

Attach Get Playlist Toggles

### IsAttachGetShowCommands

Attach Get Show Commands?

### IsAttachGetShowToggles

Attach Get Show Toggles

### IsAttachGetTrackAudioAnalysis

Attach Get Track Audio Analysis

### IsAttachGetTrackAudioFeatures

Attach Get Track Audio Features

### IsAttachGetTrackCommands

Attach Get Track Commands?

### IsAttachGetTrackToggles

Attach Get Track Toggles

### IsAttachGetUserCommands

Attach Get User Commands?

### IsAttachGetUserCurrentlyPlayingCommands

Attach Get User Currently Playing Commands?

### IsAttachGetUserCurrentlyPlayingItemCommands

Attach Get User Currently Playing Item Commands?

### IsAttachGetUserToggles

Attach Get User Toggles

### IsAttachListAlbumsCommands

Attach List Albums Commands?

### IsAttachListAlbumsToggles

Attach List Albums Toggles

### IsAttachListArtistsCommands

Attach List Artists Commands?

### IsAttachListArtistsToggles

Attach List Artists Toggles

### IsAttachListCategoriesCommands

Attach List Categories Commands?

### IsAttachListDevicesCommands

Attach List Devices Commands?

### IsAttachListEpisodesCommands

Attach List Episodes Commands?

### IsAttachListEpisodesToggles

Attach List Episodes Toggles

### IsAttachListPlaylistItemsCommands

Attach List Playlist Items Commands?

### IsAttachListPlaylistItemsToggles

Attach List Episodes Toggles

### IsAttachListPlaylistsCommands

Attach List Playlists Commands?

### IsAttachListRecommendationGenreCommands

Attach List Recommendation Genre Commands?

### IsAttachListShowsCommands

Attach List Shows Commands?

### IsAttachListShowsToggles

Attach List Shows Toggles

### IsAttachListTracksAudioFeatures

Attach List Tracks Audio Features

### IsAttachListTracksCommands

Attach List Tracks Commands?

### IsAttachListTracksToggles

Attach List Tracks Toggles


## ContextResponse

Context Response

### ExternalUrls

Known external URLs for this object

### Href

A link to the Web API endpoint providing full details of the object

### Type

The object type of the object

### Uri

The Spotify URI for the object


## CopyrightResponse

Copyright Response

### Text

The copyright text for this album

### Type

The type of copyright: C = the copyright, P = the sound recording (performance) copyright


## CurrentlyPlayingItemResponse

Currently Playing Item Response

### Actions

Allows to update the user interface based on which playback actions are available within the current context

### Context

A Context Object. Can be null

### Current

The currently playing item, Track or Episode

### Duration

Duration

### DurationTimeSpan

Duration Timespan

### Episode

The currently playing episode. Can be null.

### HasContext

Has Context?

### HasProgress

Has Progress

### IsPlaying

If something is currently playing, return true.

### PlayItemType

Play Item Type of Track or Episode

### Progress

Progress into the currently playing track or episode. Can be null.

### ProgressTimeSpan

Progress TimeSpan

### TimeStamp

Unix Millisecond Timestamp when data was fetched

### Track

The currently playing track. Can be null.

### Type

The object type of the currently playing item. Can be one of track, episode, ad or unknown.

### UserPlaybackNextCommand

Skip User’s Playback To Next Track

### UserPlaybackPauseCommand

Pause a User's Playback

### UserPlaybackPreviousCommand

Skip User’s Playback To Previous Track

### UserPlaybackResumeCommand

Resume a User's Playback


## CurrentlyPlayingResponse

Currently Playing Response

### Device

The device that is currently active

### HasDevice

Has Device?

### HasVolume

Has Volume?

### IsRepeatStateContext

Is Repeat State Context?

### IsRepeatStateOff

Is Repeat State Off?

### IsRepeatStateTrack

Is Repeat State Track?

### RepeatState

The repeat state: off, track, context

### ShuffleState

If shuffle is on or off

### UserPlaybackRepeatCommand

Set Repeat Mode On User’s Playback

### UserPlaybackRepeatContextCommand

Set Repeat Context For User’s Playback

### UserPlaybackRepeatOffCommand

Set Repeat Off For User’s Playback

### UserPlaybackRepeatTrackCommand

Set Repeat Off For User’s Playback

### UserPlaybackSeekCommand

Set Seek for User's Playback

### UserPlaybackShuffleCommand

Toggle Shuffle For User’s Playback

### UserPlaybackVolumeCommand

Set Volume for User's Playback


## CurrentUserResponse

Current User Response

### Country

The country of the user, as set in the user’s account profile. An ISO 3166-1 alpha-2 country code.This field is only available when the current user has granted access to the UserReadPrivate scope

### Email

The user’s email address, as entered by the user when creating their account. his field is only available when the current user has granted access to the UserReadEmail scope

### IsPremium

Is Premium Subscription?

### Product

The user’s Spotify subscription level: “premium”, “free”, etc. This field is only available when the current user has granted access to the UserReadPrivate scope


## DeviceResponse

Device Response

### Id

The device Id. This may be null

### IsActive

If this device is the currently active device

### IsPrivateSession

If this device is currently in a private session

### IsRestricted

Whether controlling this device is restricted. If true then no commands will be accepted by this device

### Name

The name of the device.

### TransferUserPlaybackCommand

Transfer a User's Playback

### Type

Device type, such as “computer”, “smartphone” or “speaker”

### Volume

The current volume in percent This may be null


## DisallowsResponse

Disallows Response

### IsInterruptingPlaybackNotAllowed

Interrupting playback not allowed?

### IsPausingNotAllowed

Pausing not allowed?

### IsResumingNotAllowed

Resuming not allowed?

### IsSeekingNotAllowed

Seeking not allowed? Will be set to true while playing an ad track

### IsSkippingNextNotAllowed

Skipping next not allowed? Will be set to true while playing an ad track

### IsSkippingPrevNotAllowed

Skipping previous not allowed? Will be set to true while playing an ad track

### IsTogglingRepeatContextNotAllowed

Toggling repeat context not allowed?

### IsTogglingRepeatNotAllowed

Toggling repeat not allowed?

### IsTogglingRepeatTrackNotAllowed

Toggling repeat track not allowed?

### IsTogglingShuffleNotAllowed

Toggling shuffle not allowed?

### IsTransferringPlaybackNotAllowed

Transferring playback not allowed?


## EpisodeResponse

Episode Response

### AddPlaylistItemCommand

Add Item to a Playlist

### AddUserPlaybackCommand

Start/Resume a User's Playback

### AddUserPlaybackQueueCommand

Add an item to the end of the user's current playback queue

### Description

The description of the episode

### Duration

The episode length in milliseconds

### DurationTimeSpan

Duration Timespan

### HasProgress

Has Progress?

### Images

The cover art for the episode in various sizes, widest first

### IsExplicit

Whether or not the episode has explicit content ( true = yes it does; false = no it does not OR unknown)

### IsExternallyHosted

True if the episode is hosted outside of Spotify's CDN

### IsPlayable

True if the episode is playable in the given market. Otherwise false

### Languages

A list of the languages used in the episode, identified by their ISO 639 code

### Large

Large Image

### Length

Episode Length

### Medium

Medium Image

### PlaybackStartType

Playback Start Type

### PlayItemType

Play Item Type

### Preview

A URL to a 30 second preview (MP3 format) of the episode - null if not available

### ProgressPercentage

Episode Played Progress Percentage

### ReleaseDate

The date the episode was first released, for example 1981-12-15. Depending on the precision, it might be shown as 1981 or 1981-12

### ReleaseDatePrecision

The precision with which ReleaseDate value is known: year, month, or day

### ResumePoint

The user's most recent position in the episode. Set if the supplied access token is a user token and has the scope user-read-playback-position

### Show

The show on which the episode belongs.

### Small

Small Image

### ToggleFavourite

Toggle Favourite Episode


## EpisodesRequest

Episodes Request

### Country

(Optional) Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### EpisodeType

(Required) Episode Type

### MultipleEpisodeIds

(Required) Only for EpisodeType.Multiple - Multiple Spotify Episode Ids

### SearchIsExternal

(Optional) Only for EpisodeType.Search - If true the response will include any relevant audio content that is hosted externally.

### Value

(Required) Only for EpisodeType.Search - Episode Search Term or EpisodeType.Show - Show Id


## EpisodeType

Episode Type

### Favourite

Favourite Episodes

### Multiple

Multiple Episodes

### Search

Search for Episodes

### Show

Get a Show's Episodes


## ErrorResponse

Error Response

### Message

A short description of the cause of the error

### StatusCode

The HTTP status code


## ExternalIdResponse

External Id Response

### Ean

International Article Number

### Isrc

International Standard Recording Code

### Upc

Universal Product Code


## ExternalUrlResponse

External Url Response

### Spotify

An external, public URL to the object


## FavouriteResponse

Favourite Response

### Albums

Albums

### Artists

Artist

### Episodes

Episode

### Shows

Show

### Tracks

Track


## FavouriteType

Favourite Type

### Album

Favourite Albums

### Artist

Favourite Artists

### Episode

Favourite Episodes

### Show

Favourite Shows

### Track

Favourite Tracks


## FollowersResponse

Followers Response

### Href

A link to the Web API endpoint providing full details of the followers; null if not available

### Total

The total number of followers


## FollowType

Follow Type

### Artist

Artist

### Playlist

Playlist

### User

User


## GenericCommand

Generic Command

#### Type Parameters

- TAction - Action Type

### Constructor(execute, canExecute)

Creates a new command.

| Name | Description |
| ---- | ----------- |
| execute | *System.Action*<br>The execution logic |
| canExecute | *System.Predicate{System.Boolean}*<br>The execution status logic |

### Constructor(execute)

Creates a new command that can always execute

| Name | Description |
| ---- | ----------- |
| execute | *System.Action*<br>The execution logic |

### CanExecute(parameter)

Determines whether this <a href="#genericcommand">GenericCommand</a> can execute in its current state

| Name | Description |
| ---- | ----------- |
| parameter | *System.Object*<br>Data used by the command. If the command does not require data to be passed, this object can be set to null |

#### Returns

true if this command can be executed; otherwise, false

### CanExecuteChanged

Raised when RaiseCanExecuteChanged is called

### Execute(parameter)

Executes the <a href="#genericcommand">GenericCommand</a> on the current command target

| Name | Description |
| ---- | ----------- |
| parameter | *System.Object*<br>Data used by the command. If the command does not require data to be passed, this object can be set to null |

### RaiseCanExecuteChanged

Method used to raise the <a href="#genericcommand.canexecutechanged">GenericCommand.CanExecuteChanged</a> event to indicate that the return value of the <a href="#genericcommand.canexecute(system.object)">GenericCommand.CanExecute(System.Object)</a> method has changed


## IAssetResponse

Asset Response

### Images

Images in various sizes, if available

### Large

Large Image

### Medium

Medium Image

### Small

Small Image


## IContentResponse

Content Response

### Id

The base-62 identifier that you can find at the end of the Spotify URI for the object

### Name

The name of the content


## IContextResponse

Context Response

### ExternalUrls

Known external URLs for this object.

### Href

A link to the Web API endpoint providing full details of the object

### Type

The object type of the object

### Uri

The Spotify URI for the object


## IErrorResponse

Error Response

### Error

Error Object

### IsSuccess

Is Success


## IFavourites

Favourites

### AlbumIds

Album Spotify Ids

### ArtistIds

Artist Spotify Ids

### EpisodeIds

Show Spotify Ids

### ShowIds

Show Spotify Ids

### TrackIds

Track Spotify Ids


## ImageResponse

Image Response

### Height

The image height in pixels. If unknown: null or not returned

### Url

The source URL of the image

### Width

The image width in pixels. If unknown: null or not returned


## INavigationResponse

Navigation Response

### Back

Back Link

### Error

Error Response

### Href

Href

### IsSuccess

Is Success

### Limit

Limit

### NavigationRequests

Navigation Requests

### NavigationType

Navigation Type

### Next

Next Link

### Offset

Offset

### Total

Total

### Type

Type


## IncludeGroupRequest

Include Group Request

### Album

Album (Optional)

### AppearsOn

Appears On (Optional)

### Compilation

Compliation (Optional)

### Single

Single (Optional)


## AuthenticationScopeExtensions

Extension Methods for Scope Class to allow fluent additions of scopes for the API

### AddFollowAll(scope)

Adds all scopes to a scope within the Follow section of the defined Scopes

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddImageAll(scope)

Adds all scopes to a scope within the Images section of the defined Scopes

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddLibraryAll(scope)

Adds all scopes to a scope within the Library section of the defined Scopes

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddListeningHistoryAll(scope)

Adds all scopes to a scope within the Listening History section of the defined Scopes

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddModifyAllAccess(scope)

Extension method to add all scopes with "modify" in their scope string

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddPlaybackAll(scope)

Adds all scopes to a scope within the Playback section of the defined Scopes

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddPlaylistAll(scope)

Adds all scopes to a scope within the Playlist section of the defined Scopes

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddReadAllAccess(scope)

Extension method to add all scopes with "read" in their scope string

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddSpotifyConnectAll(scope)

Adds all scopes to a scope within the Spotify Connect section of the defined Scopes

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns



### AddUsersAll(scope)

Adds all scopes to a scope within the Users section of the defined Scopes

| Name | Description |
| ---- | ----------- |
| scope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br> |

#### Returns




## IPlaybackResponse

Playback Response

### PlaybackStartType

Playback Start Type


## IPlayItemResponse

Play Item Response

### AddPlaylistItemCommand

Add Item to a Playlist

### AddUserPlaybackCommand

Start/Resume a User's Playback

### AddUserPlaybackQueueCommand

Add an item to the end of the user's current playback queue

### Duration

The item length in milliseconds.

### IsExplicit

Whether or not the item is explicit ( true = yes it does; false = no it does not OR unknown).

### IsPlayable

If true , the item is playable in the given market. Otherwise false.

### Length

Item Length

### PlayItemType

Play Item Type

### Preview

A link to a 30 second preview (MP3 format) of the item.

### ToggleFavourite

Toggle Favourite Episode


## IPlaylistItemResponse

Playlist Item Response

### Current

Current Track or Episode

### PlayItemType

Play Item Type of Track or Episode

### RemovePlaylistItemCommand

Remove Items from a Playlist


## IResponse

Response


## ISpotifySdkClient

Spotify SDK Client

### AddPlaylistAsync(request)

Add Playlist 
Scopes: PlaylistModifyPublic, PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| request | *Spotify.NetStandard.Sdk.AddPlaylistRequest*<br>(Required) Add Playlist Request |

#### Returns

Playlist Response

### AddPlaylistItemAsync(playlistId, playItemType, id, position)

Add Playlist Item 
Scopes: PlaylistModifyPublic, PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| playItemType | *Spotify.NetStandard.Sdk.PlayItemType*<br>(Required) Track or Episode |
| id | *System.String*<br>(Required) Spotify Track Id or Episode Id |
| position | *System.Nullable{System.Int32}*<br>(Optional) The positions to remove items by id, a zero-based index |

#### Returns

Snapshot Response

### AddPlaylistItemsAsync(playlistId, requests, position)

Add Playlist Items 
Scopes: PlaylistModifyPublic, PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| requests | *System.Collections.Generic.List{Spotify.NetStandard.Sdk.AddPlaylistItemRequest}*<br>(Required) The items to add to the playlist |
| position | *System.Nullable{System.Int32}*<br>(Optional) The position to insert the items, a zero-based index |

#### Returns

Snapshot Response

### AddUserPlaybackAsync(playbackStartType, id, deviceId, position, offsetId)

Add User Playback 
Scopes: ConnectModifyPlaybackState


| Name | Description |
| ---- | ----------- |
| playbackStartType | *Spotify.NetStandard.Sdk.PlaybackStartType*<br>(Required) Playback Start Type |
| id | *System.String*<br>(Required) PlaybackStartType.Track - Spotify Track Id, PlaybackStartType.Episode - Spotify Episode Id, PlaybackStartType.Album - Spotify Album Id, PlaybackStartType.Artist - Spotify Artist Id, PlaybackStartType.Playlist - Spotify Playlist Id, PlaybackStartType.Show - Spotify Show Id |
| deviceId | *System.String*<br>(Optional) Spotify Device Id |
| position | *System.Nullable{System.Int32}*<br>(Optional) Indicates from what position to start playback. Must be a positive number. Passing in a position that is greater than the length of the track will cause the player to start playing the next song. |
| offsetId | *System.String*<br>(Optional) Only for PlaybackStartType.Album, PlaybackStartType.Artist, PlaybackStartType.Playlist and PlaybackStartType.Show. Only use either Position or OffsetId. Offset Id indicates from where in the context playback should start. |

*System.ArgumentException:* Thrown when Position and OffsetId are Provided

#### Returns

Status Response

### AddUserPlaybackQueueAsync(playItemType, id, deviceId)

Add User Playback Queue 
Scopes: ConnectModifyPlaybackState


| Name | Description |
| ---- | ----------- |
| playItemType | *Spotify.NetStandard.Sdk.PlayItemType*<br>(Required) Track or Episode |
| id | *System.String*<br>(Required) PlayItemType.Track - Spotify Track Id, PlayItemType.Episode - Spotify Episode Id |
| deviceId | *System.String*<br>(Optional) Spotify Device Id |

#### Returns

Status Response

### AuthenticationRedirectUri

Authentication Redirect Uri

### AuthenticationState

Authentication State

### AuthenticationToken

Authentication Token

### AuthenticationTokenRequired

Authentication Token Required Event

### AuthenticationVerifier

Only for AuthenticationFlowType.AuthorisationCodeWithProofKeyForCodeExchange - Proof Key for Code Exchange (PKCE) Verifier

### ClientException

Client Exception Event

### CommandActions

Command Actions

### Config

Configuration

### Country

ISO 3166-1 alpha-2 country code e.g. GB for Country and Market

### CurrentDevice

Current Device - Set by Get User Currently Playing

### CurrentPlaylist

Current Playlist - Set by Get Playlist

### CurrentUser

Current User - Set by Get Current User

### Favourites

Favourites

### GetAlbumAsync(albumId)

Get Album

| Name | Description |
| ---- | ----------- |
| albumId | *System.String*<br>(Required) Spotify Album Id |

#### Returns

Album Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetArtistAsync(artistId)

Get Artist

| Name | Description |
| ---- | ----------- |
| artistId | *System.String*<br>(Required) Spotify Artist Id |

#### Returns

Artist Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetAsync(id)

Get

#### Type Parameters

- TResponse - Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, AudioAnalysisResponse, EpisodeResponse, ShowResponse, CurrentUserResponse, UserResponse, PlaylistImageResponse, CurrentlyPlayingResponse, CurrentlyPlayingItemResponse

| Name | Description |
| ---- | ----------- |
| id | *System.String*<br>Id |

#### Returns

Response

### GetAuthenticationTokenAsync(authenticationFlowType, authenticationResponseUri)

Get Authentication Token

| Name | Description |
| ---- | ----------- |
| authenticationFlowType | *Spotify.NetStandard.Sdk.AuthenticationFlowType*<br>(Required) Authentication Flow Type |
| authenticationResponseUri | *System.Uri*<br>(Required) Only for AuthenticationFlowType.AuthorisationCode or AuthenticationFlowType.ImplicitGrant - Authentication Response Uri |

#### Returns

AuthenticationTokenResponse on Success, Null if Not

*System.ArgumentNullException:* Thrown if authenticationResponseUri and AuthenticationRedirectUri aren't set

*AuthenticationAccessCodeNotFoundException:* Only thrown for AuthenticationFlowType.AuthorisationCode if Authorisation Code not returned

*AuthenticationAccessTokenNotFoundException:* Only thrown for AuthenticationFlowType.ImplicitGrant if Access Token was not returned

*AuthenticationStateNotMatchedException:* Only thrown for AuthenticationFlowType.AuthorisationCode and AuthenticationFlowType.ImplicitGrant is State doesn't match

### GetAuthenticationUri(authenticationFlowType, authenticationScope, showAuthenticationDialog)

Get Authentication Uri

| Name | Description |
| ---- | ----------- |
| authenticationFlowType | *Spotify.NetStandard.Sdk.AuthenticationFlowType*<br>(Required) Only AuthenticationFlowType.AuthorisationCode or AuthenticationFlowType.ImplicitGrant supported |
| authenticationScope | *Spotify.NetStandard.Sdk.AuthenticationScopeRequest*<br>(Optional) Authentication Scope |
| showAuthenticationDialog | *System.Boolean*<br>(Optional) Whether or not to force the user to approve the app again if they’ve already done so. |

*System.ArgumentNullException:* Only thrown when AuthenticationRedirectUri is not supplied

*System.ArgumentOutOfRangeException:* Only thrown when AuthenticationFlowType unsupported

### GetCategoryAsync(categoryId)

Get Category

| Name | Description |
| ---- | ----------- |
| categoryId | *System.String*<br>(Required) Spotify Category Id |

#### Returns

Category Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetCurrentUserAsync

Get Current User 
Scopes: UserReadEmail, UserReadPrivate


#### Returns

Current User Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetEpisodeAsync(episodeId)

Get Episode

| Name | Description |
| ---- | ----------- |
| episodeId | *System.String*<br>(Required) Spotify Episode Id |

#### Returns

Episode Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetFavouriteAsync(favouriteType, id)

Get Favourite

| Name | Description |
| ---- | ----------- |
| favouriteType | *Spotify.NetStandard.Sdk.FavouriteType*<br>(Required) Favourite Type |
| id | *System.String*<br>(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id |

#### Returns

Bool Response

### GetFollowAsync(followType, id, userId)

Get Follow 
Scopes: FollowType.FollowArtist FollowType.FollowUser - FollowRead, FollowType.FollowPlaylist - PlaylistReadPrivate


| Name | Description |
| ---- | ----------- |
| followType | *Spotify.NetStandard.Sdk.FollowType*<br>(Required) Follow Type |
| id | *System.String*<br>(Required) Spotify Item Id |
| userId | *System.String*<br>(Required) Only for FollowType.FollowPlaylist |

#### Returns

Bool Response

### GetPlaylistAsync(playlistId, fields)

Get Playlist

| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| fields | *System.String*<br>(Optional) Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned. |

#### Returns

Playlist Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetPlaylistImageAsync(playlistId)

Get Playlist Image

| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |

#### Returns

Playlist Image Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetSavedAsync(savedType, id)

Get Saved 
Scopes: LibraryRead


| Name | Description |
| ---- | ----------- |
| savedType | *Spotify.NetStandard.Sdk.SavedType*<br>(Required) Saved Type |
| id | *System.String*<br>(Required) Spotify Item Id |

#### Returns

Bool Response

### GetShowAsync(showId)

Get Show

| Name | Description |
| ---- | ----------- |
| showId | *System.String*<br>(Required) Spotify Show Id |

#### Returns

Show Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetToggleAsync(toggleType, id, itemType)

Get Toggle

| Name | Description |
| ---- | ----------- |
| toggleType | *Spotify.NetStandard.Sdk.ToggleType*<br>Toggle Type |
| id | *System.String*<br>Toggle Id |
| itemType | *System.Byte*<br>Toggle Item Type |

#### Returns

Toggle

### GetTrackAsync(trackId)

Get Track

| Name | Description |
| ---- | ----------- |
| trackId | *System.String*<br>(Required) Spotify Track Id |

#### Returns

Track Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetTrackAudioAnalysisAsync(trackId)

Get Track Audio Analysis

| Name | Description |
| ---- | ----------- |
| trackId | *System.String*<br>(Required) Spotify Track Id |

#### Returns

Audio Analysis Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetTrackAudioFeaturesAsync(trackId)

Get Track Audio Features

| Name | Description |
| ---- | ----------- |
| trackId | *System.String*<br>(Required) Spotify Track Id |

#### Returns

Audio Features Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetUserAsync(userId)

Get User

| Name | Description |
| ---- | ----------- |
| userId | *System.String*<br>(Required) Spotify User Id |

#### Returns

User Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetUserCurrentlyPlayingAsync

Get User Currently Playing 
Scopes: ConnectReadPlaybackState


#### Returns

Currently Playing Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### GetUserCurrentlyPlayingItemAsync

Get User Currently Playing Item 
Scopes: ConnectReadCurrentlyPlaying, ConnectReadPlaybackState


#### Returns

Currently Playing Item Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### IsPlaylistOwnedByCurrentUser(playlist)

Is Playlist Owned by Current User? 
Prerequisite: GetCurrentUser


| Name | Description |
| ---- | ----------- |
| playlist | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |

#### Returns

True if Playlist Owned, False if Not

### IsUserLoggedIn

Is User Logged In

### Limit

Number of items to return per request

### ListAlbumsAsync(albumsRequest)

List Albums 
Scopes: AlbumType.UserSaved - LibraryRead


| Name | Description |
| ---- | ----------- |
| albumsRequest | *Spotify.NetStandard.Sdk.AlbumsRequest*<br>(Required) Albums Request |

#### Returns

Navigation Response of Album Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListAlbumsAsync(navigationResponse)

List Albums 
Scopes: AlbumType.UserSaved - LibraryRead


| Name | Description |
| ---- | ----------- |
| navigationResponse | *Spotify.NetStandard.Sdk.NavigationResponse{Spotify.NetStandard.Sdk.AlbumResponse}*<br>(Required) Navigation Response of Album Response |

#### Returns

Navigation Response of Album Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListArtistsAsync(artistsRequest)

List Artists 
Scopes: ArtistType.UserFollowed - FollowRead, UserFollowed.UserTop - LibraryRead


| Name | Description |
| ---- | ----------- |
| artistsRequest | *Spotify.NetStandard.Sdk.ArtistsRequest*<br>(Required) Artists Request |

#### Returns

Navigation Response of Artist Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListArtistsAsync(navigationResponse)

List Artists 
Scopes: ArtistType.UserFollowed - FollowRead, UserFollowed.UserTop - LibraryRead


| Name | Description |
| ---- | ----------- |
| navigationResponse | *Spotify.NetStandard.Sdk.NavigationResponse{Spotify.NetStandard.Sdk.ArtistResponse}*<br>(Required) Navigation Response of Artist Response |

#### Returns

Navigation Response of Artist Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListAsync(Spotify.NetStandard.Sdk.NavigationResponse)

List

#### Type Parameters

- TResponse - Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, PlaylistItemResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, EpisodeResponse, ShowResponse

#### Returns

Navigation Response of Response

### ListAsync(request)

List

#### Type Parameters

- TRequest - Request Type: CategoriesRequest, ArtistsRequest, PlaylistsRequest, PlaylistItemsRequest, AlbumsRequest, TracksRequest, AudioFeaturesRequest, EpisodesRequest, ShowsRequest
- TResponse - Response Type: CategoryResponse, ArtistResponse, PlaylistResponse, PlaylistItemResponse, AlbumResponse, TrackResponse, AudioFeaturesResponse, EpisodeResponse, ShowResponse, DeviceResponse, RecommendationGenreResponse

| Name | Description |
| ---- | ----------- |
| request | Request |

#### Returns

Navigation Response of Response

### ListAudioFeaturesAsync(audioFeaturesRequest)

List Audio Features

| Name | Description |
| ---- | ----------- |
| audioFeaturesRequest | *Spotify.NetStandard.Sdk.AudioFeaturesRequest*<br>(Required) Audio Features Request |

#### Returns

List of Audio Features Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListCategoriesAsync(categoriesRequest)

List Categories

| Name | Description |
| ---- | ----------- |
| categoriesRequest | *Spotify.NetStandard.Sdk.CategoriesRequest*<br>(Optional) Categories Request |

#### Returns

NavigationResponse of Category Responses

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListCategoriesAsync(navigationResponse)

List Categories

| Name | Description |
| ---- | ----------- |
| navigationResponse | *Spotify.NetStandard.Sdk.NavigationResponse{Spotify.NetStandard.Sdk.CategoryResponse}*<br>(Required) NavigationResponse of Category Responses |

#### Returns

NavigationResponse of Category Responses

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListEpisodesAsync(episodesRequest)

List Episodes

| Name | Description |
| ---- | ----------- |
| episodesRequest | *Spotify.NetStandard.Sdk.EpisodesRequest*<br>(Required) Episodes Request |

#### Returns

Navigation Response of Episode Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListEpisodesAsync(navigationResponse)

List Episodes

| Name | Description |
| ---- | ----------- |
| navigationResponse | *Spotify.NetStandard.Sdk.NavigationResponse{Spotify.NetStandard.Sdk.EpisodeResponse}*<br>(Required) Navigation Response of Episode Response |

#### Returns

Navigation Response of Episode Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListFavouriteAsync(favouriteType, multipleIds)

List Favourite

| Name | Description |
| ---- | ----------- |
| favouriteType | *Spotify.NetStandard.Sdk.FavouriteType*<br>(Required) Favourite Type |
| multipleIds | *System.Collections.Generic.List{System.String}*<br>(Required) FavouriteType.Album - Multiple Spotify Album Ids, FavouriteType.Artist - Multiple Spotify Artist Ids, FavouriteType.Track - Multiple Spotify Track Ids, FavouriteType.Show - Multiple Spotify Show Ids, FavouriteType.Episode - Multiple Spotify Episode Ids |

#### Returns

Navigation Response of Bool

### ListFollowAsync(followType, multipleIds, playlistId)

List Follow

Scopes: FollowType.FollowArtist FollowType.FollowUser : FollowRead, FollowType.FollowPlaylist : PlaylistReadPrivate

| Name | Description |
| ---- | ----------- |
| followType | *Spotify.NetStandard.Sdk.FollowType*<br>(Required) FollowType Type |
| multipleIds | *System.Collections.Generic.List{System.String}*<br>(Required) FollowType.FollowArtist - Multiple Spotify Artist Ids, FollowType.FollowUser and FollowType.Playlist - Multiple Spotify User Ids |
| playlistId | *System.String*<br>(Required) Only for FollowType.FollowPlaylist |

#### Returns

Navigation Response of bool

### ListPlaylistItemsAsync(navigationResponse)

List Playlist Items

| Name | Description |
| ---- | ----------- |
| navigationResponse | *Spotify.NetStandard.Sdk.NavigationResponse{Spotify.NetStandard.Sdk.PlaylistItemResponse}*<br>(Required) Navigation Response of Playlist Item Response |

#### Returns

Navigation Response of Playlist Item Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListPlaylistItemsAsync(playlistItemsRequest)

List Playlist Items

| Name | Description |
| ---- | ----------- |
| playlistItemsRequest | *Spotify.NetStandard.Sdk.PlaylistItemsRequest*<br>(Required) Playlist Items Request |

#### Returns

Navigation Response of Track Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListPlaylistsAsync(navigationResponse)

List Playlists 
Scopes: PlaylistType.CurrentUser - PlaylistReadPrivate, PlaylistReadCollaborative


| Name | Description |
| ---- | ----------- |
| navigationResponse | *Spotify.NetStandard.Sdk.NavigationResponse{Spotify.NetStandard.Sdk.PlaylistResponse}*<br>(Required) Navigation Response of Playlist Response |

#### Returns

Navigation Response of Playlist Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListPlaylistsAsync(playlistsRequest)

List Playlists 
Scopes: PlaylistType.CurrentUser - PlaylistReadPrivate, PlaylistReadCollaborative


| Name | Description |
| ---- | ----------- |
| playlistsRequest | *Spotify.NetStandard.Sdk.PlaylistsRequest*<br>(Required) Playlists Request |

#### Returns

Navigation Response of Playlist Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListRecommendationGenresAsync

List Recommendation Genres

#### Returns

List of Recommendation Genre Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListSavedAsync(savedType, multipleIds)

List Saved

Scopes: LibraryRead

| Name | Description |
| ---- | ----------- |
| savedType | *Spotify.NetStandard.Sdk.SavedType*<br>(Required) Saved Type |
| multipleIds | *System.Collections.Generic.List{System.String}*<br>(Required) SavedType.Album - Multiple Spotify Album Ids, SavedType.Track - Multiple Spotify Track Ids, SavedType.Show - Multiple Spotify Show Ids |

#### Returns

Navigation Response of bool

### ListShowsAsync(navigationResponse)

List Shows 
Scopes: ShowType.UserSaved - LibraryRead


| Name | Description |
| ---- | ----------- |
| navigationResponse | *Spotify.NetStandard.Sdk.NavigationResponse{Spotify.NetStandard.Sdk.ShowResponse}*<br>(Required) Navigation Response of Show Response |

#### Returns

Navigation Response of Show Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListShowsAsync(showsRequest)

List Shows 
Scopes: ShowType.UserSaved - LibraryRead


| Name | Description |
| ---- | ----------- |
| showsRequest | *Spotify.NetStandard.Sdk.ShowsRequest*<br>(Required) Shows Request |

#### Returns

Navigation Response of Episode Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListTogglesAsync(toggleType, multipleIds, playlistId, itemType)

List Toggles

| Name | Description |
| ---- | ----------- |
| toggleType | *Spotify.NetStandard.Sdk.ToggleType*<br>Toggle Type |
| multipleIds | *System.Collections.Generic.List{System.String}*<br>Multiple Ids |
| playlistId | *System.String*<br>Playlist Id |
| itemType | *System.Byte*<br>Item Type |

#### Returns

List of Toggle

### ListTracksAsync(navigationResponse)

List Tracks 
Scopes: TrackType.UserRecentlyPlayed - ListeningRecentlyPlayed, TrackType.UserSaved - LibraryRead, TrackType.UserTop - ListeningTopRead


| Name | Description |
| ---- | ----------- |
| navigationResponse | *Spotify.NetStandard.Sdk.NavigationResponse{Spotify.NetStandard.Sdk.TrackResponse}*<br>(Required) Navigation Response of Track Response |

#### Returns

Navigation Response of Track Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListTracksAsync(tracksRequest)

List Tracks 
Scopes: TrackType.UserRecentlyPlayed - ListeningRecentlyPlayed, TrackType.UserSaved - LibraryRead, TrackType.UserTop - ListeningTopRead


| Name | Description |
| ---- | ----------- |
| tracksRequest | *Spotify.NetStandard.Sdk.TracksRequest*<br>(Required) Tracks Request |

#### Returns

Navigation Response of Track Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### ListUserDevicesAsync

List User Devices 
Scopes: ConnectReadPlaybackState


#### Returns

Navigation Response of Device Response

*AuthenticationTokenRequiredException:* Thrown if AuthenticationTokenRequired Event not Subscribed to

### Locale

ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB

### Logout

Logout

### NavigationType

Navigation Type (Default: NavigationType.Next)

### PlaylistItemResponseMovedHandler(response, args)

Playlist Item Response Removed Handler

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |
| args | *Spotify.NetStandard.Sdk.ResponseMovedArgs*<br>Playlist Item Response Removed Argument |

### PlaylistItemResponseRemovedHandler(response, args)

Playlist Item Response Removed Handler

| Name | Description |
| ---- | ----------- |
| response | *Spotify.NetStandard.Sdk.PlaylistResponse*<br>Playlist Response |
| args | *Spotify.NetStandard.Sdk.ResponseRemovedArgs{Spotify.NetStandard.Sdk.PlaylistItemResponse}*<br>Playlist Item Response Removed Argument |

### RemovePlaylistItemAsync(playlistId, playItemType, id, positions, snapshotId)

Remove Playlist Item 
Scopes: PlaylistModifyPublic, PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| playItemType | *Spotify.NetStandard.Sdk.PlayItemType*<br>(Required) Track or Episode |
| id | *System.String*<br>(Required) Spotify Track Id or Episode Id |
| positions | *System.Collections.Generic.List{System.Int32}*<br>(Optional) The positions to remove items by id, a zero-based index |
| snapshotId | *System.String*<br>(Optional) The playlist’s snapshot ID against which you want to make the changes. The API will validate that the specified tracks exist and in the specified positions and make the changes, even if more recent changes have been made to the playlist |

#### Returns

Snapshot Response

### RemovePlaylistItemsAsync(playlistId, removePlaylistItemRequests, snapshotId)

Remove Playlist Items 
Scopes: PlaylistModifyPublic, PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| removePlaylistItemRequests | *System.Collections.Generic.List{Spotify.NetStandard.Sdk.RemovePlaylistItemRequest}*<br>(Required) The items to remove from the Playlist |
| snapshotId | *System.String*<br>(Optional) The playlist’s snapshot ID against which you want to make the changes. The API will validate that the specified tracks exist and in the specified positions and make the changes, even if more recent changes have been made to the playlist |

#### Returns

Snapshot Response

### ResponseError

Response Error Event

### ResponseUserPlaybackSuccess

Response User Playback Success

### SearchAsync(searchRequest)

Search

| Name | Description |
| ---- | ----------- |
| searchRequest | *Spotify.NetStandard.Sdk.SearchRequest*<br>(Required) Search Request |

#### Returns

Search Response

### Set(favourites)

Set

| Name | Description |
| ---- | ----------- |
| favourites | *Spotify.NetStandard.Sdk.IFavourites*<br>Favourites |

#### Returns

ISpotifySdkClient

### Set(cultureInfo)

Set

| Name | Description |
| ---- | ----------- |
| cultureInfo | *System.Globalization.CultureInfo*<br>(Required) Culture Info |

#### Returns

ISpotifySdkClient

### Set(country, locale)

Set

| Name | Description |
| ---- | ----------- |
| country | *System.String*<br>(Optional) ISO 3166-1 alpha-2 country code e.g. GB |
| locale | *System.String*<br>(Optional) ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB |

#### Returns

ISpotifySdkClient

### SetAuthenticationTokenClientCredentialsAsync

Set Authentication Token Client Credentials

### SetFavouriteAsync(favouriteType, setType, multipleIds)

Set Favourite

| Name | Description |
| ---- | ----------- |
| favouriteType | *Spotify.NetStandard.Sdk.FavouriteType*<br>(Required) Favourite Type |
| setType | *Spotify.NetStandard.Sdk.SetType*<br>(Required) Set Type |
| multipleIds | *System.Collections.Generic.List{System.String}*<br>(Required) FavouriteType.Album - Multiple Spotify Album Ids, FavouriteType.Artist - Multiple Spotify Artist Ids, FavouriteType.Track - Multiple Spotify Track Ids, FavouriteType.Show - Multiple Spotify Show Ids, FavouriteType.Episode - Multiple Spotify Episode Ids |

#### Returns

Status Response

### SetFavouriteAsync(favouriteType, setType, id)

Set Favourite

| Name | Description |
| ---- | ----------- |
| favouriteType | *Spotify.NetStandard.Sdk.FavouriteType*<br>(Required) Favourite Type |
| setType | *Spotify.NetStandard.Sdk.SetType*<br>(Required) Set Type |
| id | *System.String*<br>(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id |

#### Returns

Status Response

### SetFollowAsync(followType, setType, multipleIds, playlistId)

Set Follow 
Scopes: FollowModify, FollowType.Playlist and SetType.Remove - PlaylistModifyPublic or PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| followType | *Spotify.NetStandard.Sdk.FollowType*<br>(Required) Follow Type |
| setType | *Spotify.NetStandard.Sdk.SetType*<br>(Required) Set Type |
| multipleIds | *System.Collections.Generic.List{System.String}*<br>(Required) Only for FollowType.Artist - Multiple Spotify Artist Ids, FollowType.User - Multiple Spotify User Ids |
| playlistId | *System.String*<br>(Required) Only for FollowType.Playlist |

#### Returns

Status Response

### SetFollowAsync(followType, setType, id)

Set Follow 
Scopes: FollowModify, FollowType.Playlist and SetType.Remove - PlaylistModifyPublic or PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| followType | *Spotify.NetStandard.Sdk.FollowType*<br>(Required) Follow Type |
| setType | *Spotify.NetStandard.Sdk.SetType*<br>(Required) Set Type |
| id | *System.String*<br>(Required) FollowType.Artist - Spotify Artist Id, FollowType.User - Spotify User Id, FollowType.Playlist - Spotify Playlist Id |

#### Returns

Status Response

### SetPlaylistAsync(request)

Set Playlist 
Scopes: PlaylistModifyPublic, PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| request | *Spotify.NetStandard.Sdk.SetPlaylistRequest*<br>(Required) Set Playlist Request |

#### Returns

Playlist Response

### SetPlaylistImageAsync(playlistId, jpegFileBytes)

Set Playlist Image 
Scopes: ImageUserGeneratedContentUpload


| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| jpegFileBytes | *System.Byte[]*<br>(Required) JPEG Image File Bytes (256Kb Max File Size) |

#### Returns

Status Response

### SetPlaylistItemAsync(playlistId, playItemType, id)

Set Playlist Item 
Scopes: PlaylistModifyPublic, PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| playItemType | *Spotify.NetStandard.Sdk.PlayItemType*<br>Track or Episode |
| id | *System.String*<br>Spotify Track or Episode Id |

#### Returns

Status Response

### SetPlaylistItemOrderAsync(playlistId, rangeStart, insertBefore, rangeLength, snapshotId)

Set Playlist Item Order

| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| rangeStart | *System.Int32*<br>(Required) Position of the first item to be reordered |
| insertBefore | *System.Int32*<br>(Required) Position where the items should be inserted. To reorder the items to the end of the playlist, simply set insertBefore to the position after the last item. |
| rangeLength | *System.Nullable{System.Int32}*<br>(Optional) Amount of items to be reordered. Defaults to 1 if not set. The range of items to be reordered begins from the rangeStart position, and includes the rangeLength subsequent items. |
| snapshotId | *System.String*<br>(Optional) Playlist’s snapshot ID against which you want to make the changes. |

#### Returns

Status Response

### SetPlaylistItemsAsync(playlistId, addPlaylistItemRequests)

Set Playlist Items 
Scopes: PlaylistModifyPublic, PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| playlistId | *System.String*<br>(Required) Spotify Playlist Id |
| addPlaylistItemRequests | *System.Collections.Generic.List{Spotify.NetStandard.Sdk.AddPlaylistItemRequest}*<br>(Required) The items to add in the Playlist |

#### Returns

Status Response

### SetSavedAsync(savedType, setType, multipleIds)

Set Saved 
Scopes: LibraryModify


| Name | Description |
| ---- | ----------- |
| savedType | *Spotify.NetStandard.Sdk.SavedType*<br>(Required) Saved Type |
| setType | *Spotify.NetStandard.Sdk.SetType*<br>(Required) Set Type |
| multipleIds | *System.Collections.Generic.List{System.String}*<br>(Required) SavedType.Album - Multiple Spotify Album Ids, SavedType.Track - Multiple Spotify Track Ids, SavedType.Show - Multiple Spotify Show Ids |

#### Returns

Status Response

### SetSavedAsync(savedType, setType, id)

Set Saved 
Scopes: LibraryModify


| Name | Description |
| ---- | ----------- |
| savedType | *Spotify.NetStandard.Sdk.SavedType*<br>(Required) Saved Type |
| setType | *Spotify.NetStandard.Sdk.SetType*<br>(Required) Set Type |
| id | *System.String*<br>(Required) Spotify Item Id |

#### Returns

Status Response

### SetToggleAsync(toggle)

Set Toggle

| Name | Description |
| ---- | ----------- |
| toggle | *Spotify.NetStandard.Sdk.Toggle*<br>Toggle |

### SetUserPlaybackAsync(playbackType, deviceId, option)

Set User Playback 
Scopes: ConnectModifyPlaybackState


| Name | Description |
| ---- | ----------- |
| playbackType | *Spotify.NetStandard.Sdk.PlaybackType*<br>(Required) Playback Type |
| deviceId | *System.String*<br>(Optional) Spotify Device Id |
| option | *System.Nullable{System.Int32}*<br>(Required) Only for PlaybackType.Seek - Position in milliseconds to seek to and PlaybackType.Volume - Value from 0 to 100 inclusive |

#### Returns

Status Response

### SpotifyClient

Spotify Client

### ToggleFavouriteAsync(favouriteType, id)

Toggle Favourite

| Name | Description |
| ---- | ----------- |
| favouriteType | *Spotify.NetStandard.Sdk.FavouriteType*<br>(Required) Favourite Type |
| id | *System.String*<br>(Required) FavouriteType.Album - Spotify Album Id, FavouriteType.Artist - Spotify Artist Id, FavouriteType.Track - Spotify Track Id, FavouriteType.Show - Spotify Show Id, FavouriteType.Episode - Spotify Episode Id |

#### Returns

Bool Response

### ToggleFollowAsync(followType, id)

Toggle Follow 
Scopes: FollowType.FollowArtist FollowType.FollowUser - FollowRead and FollowModify, FollowType.FollowPlaylist - FollowModify and PlaylistModifyPublic or PlaylistModifyPrivate


| Name | Description |
| ---- | ----------- |
| followType | *Spotify.NetStandard.Sdk.FollowType*<br>(Required) Follow Type |
| id | *System.String*<br>(Required) FollowType.Artist - Spotify Artist Id, FollowType.User - Spotify User Id, FollowType.Playlist - Spotify Playlist Id |

#### Returns

Bool Response

### ToggleSavedAsync(savedType, id)

Toggle Saved 
Scopes: LibraryModify


| Name | Description |
| ---- | ----------- |
| savedType | *Spotify.NetStandard.Sdk.SavedType*<br>(Required) Saved Type |
| id | *System.String*<br>(Required) SavedType.Album - Spotify Album Id, SavedType.Track - Spotify Track Id, SavedType.Show - Spotify Show Id |

#### Returns

Status Response


## LinkedTrackResponse

Linked Track Response


## NavigationRequest

Navigation Request

### Limit

Maximum number of objects to return

### Offset

Index of first object to return


## NavigationResponse

Navigation Response

#### Type Parameters

- TResponse - Response Type

### Back

Back Link

### Href

Href

### Items

Items

### Limit

Limit

### NavigationRequests

Navigation Requests

### NavigationType

Navigation Type

### Next

Next Link

### Offset

Offset

### Total

Total

### Type

Type


## NavigationType

Navigation Type

### Back

Navigate Back

### Href

Href

### Next

Navigate Next


## PlaybackStartType

Playback Start Type

### Album

Album

### Artist

Artist

### Episode

Episode

### Playlist

Playlist

### Show

Show

### Track

Track


## PlaybackType

Playback Type

### Device

Transfer a User's Playback

### Next

Skip User’s Playback To Next Track

### Pause

Pause a User's Playback

### Previous

Skip User’s Playback To Previous Track

### RepeatContext

Set Repeat Mode On User’s Playback as Context

### RepeatOff

Set Repeat Mode On User’s Playback as Off

### RepeatTrack

Set Repeat Mode On User’s Playback as Track

### Resume

Resume a User's Playback

### Seek

Seek To Position In Currently Playing Track

### ShuffleOff

Toggle Shuffle For User’s Playback as Off

### ShuffleOn

Toggle Shuffle For User’s Playback as On

### Volume

Set Volume For User's Playback


## PlayItemType

Play Item Type

### Episode

Episode

### Track

Track


## PlaylistImageResponse

Playlist Image Response

### Command

Command

### Id

Playlist Id

### Images

Images in various sizes, if available

### Large

Large Image

### Medium

Medium Image

### Small

Small Image


## PlaylistItemResponse

Playlist Item Response

### AddedAt

The date and time the Track or Episode was added

### AddedBy

The Spotify user who added the Track or Episode

### Current

Play Item Response of Current Track or Episode

### Episode

Information about the Episode

### IsLocal

Whether this track is a local file or not.

### PlayItemType

Play Item Type of Track or Episode

### RemovePlaylistItemCommand

Remove Items from a Playlist

### Track

Information about the Track


## PlaylistItemsRequest

Playlist Items Request

### Country

(Optional) Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### Fields

(Optional) Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are returned

### PlaylistId

(Required) Spotify Playlist Id


## PlaylistResponse

Playlist Response

### AddUserPlaybackCommand

Start/Resume a User's Playback

### Collaborative

Returns true if the owner allows other users to modify the playlist

### Description

The playlist description. Only returned for modified, verified playlists, otherwise null

### Followers

Information about the followers of the playlist

### Images

Images for the playlist. The array may be empty or contain up to three images. The images are returned by size in descending order

### IsEditable

Is Editable, Requires Current User

### IsOwnPlaylist

Is Own Playlist, Requires Current User

### Large

Large Image

### Medium

Medium Image

### Owner

The user who owns the playlist

### PlaybackStartType

Playback Start Type

### Public

The playlist's public/private status: true the playlist is public, false the playlist is private, null the playlist status is not relevant

### SetPlaylistCommand

Is Own Playlist Only - Change a Playlist's Details

### SetPlaylistImageCommand

Is Own Playlist Only - Upload a Custom Playlist Cover Image -

### Small

Small Image

### SnapshotId

The version identifier for the current playlist

### ToggleFollow

Get Playlist Only - Toggle Following State for Playlist

### TotalFollowers

The total number of followers

### Tracks

Information about the items of the playlist


## PlaylistsRequest

Playlists Request

### Country

(Optional) Only for PlaylistType.Search, PlaylistType.Featured and PlaylistType.Category - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### Locale

(Optional) Only for PlaylistType.Featured - Override Client Locale as ISO 639-1 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore e.g. en_GB

### PlaylistType

(Required) Playlist Type

### SearchIsExternal

(Optional) Only for PlaylistType.Search, If true the response will include any relevant audio content that is hosted externally.

### Value

(Required) Only for PlaylistType.Search - Playlist Search Term, PlaylistType.Category - Category Id, and PlaylistType.User - User Id


## PlaylistType

Playlist Type

### Category

Category Playlists

### CurrentUser

Current User's Playlists

### CurrentUserAddable

Current User's Addable Playlists

### Featured

Featured Playlists

### Search

Search for Playlists

### User

User's Playlists


## RecommendationGenreResponse

Available Recommendation Genre Seed Response

### Command

Command

### Id

Id


## RecommendationRequest

Recommendation Request

### MaximumTuneableTrack

(Optional) Multiple values. For each tunable track attribute, a hard ceiling on the selected track attribute’s value can be provided

### MinimumTuneableTrack

(Optional) Multiple values. For each tunable track attribute, a hard floor on the selected track attribute’s value can be provided

### SeedArtistIds

(Required) List of Spotify IDs for seed artists. Up to 5 seed values may be provided in any combination of seedArtists, seedTracks and seedGenres

### SeedGenre

One of any genres in the set of available genres. Up to 5 seed values may be provided in any combination of seedArtists, seedTracks and seedGenres

### SeedGenres

(Required) List of any genres in the set of available genres. Up to 5 seed values may be provided in any combination of seedArtists, seedTracks and seedGenres

### SeedTrackIds

(Required) List of Spotify IDs for a seed track. Up to 5 seed values may be provided in any combination of seedArtists, seedTracks and seedGenres

### TargetTotal

The target size of the list of recommended tracks. Default: 20. Minimum: 1. Maximum: 100

### TargetTuneableTrack

(Optional) Multiple values. For each of the tunable track attributes (below) a target value may be provided


## RecommendationSeedResponse

Recommendation Seed Response

### AfterFilteringSize

The number of tracks available after min_* and max_* filters have been applied

### AfterRelinkingSize

The number of tracks available after relinking for regional availability

### InitialPoolSize

The number of recommended tracks available for this seed


## RelayCommand

Relay Command

### Constructor(execute, canExecute)

Creates a new command.

| Name | Description |
| ---- | ----------- |
| execute | *System.Action{System.Object}*<br>The execution logic. |
| canExecute | *System.Func{System.Boolean}*<br>The execution status logic |

### Constructor(execute)

Creates a new command that can always execute

| Name | Description |
| ---- | ----------- |
| execute | *System.Action{System.Object}*<br>The execution logic |

### CanExecute(parameter)

Determines whether this <a href="#relaycommand">RelayCommand</a> can execute in its current state

| Name | Description |
| ---- | ----------- |
| parameter | *System.Object*<br>Data used by the command. If the command does not require data to be passed, this object can be set to null |

#### Returns

true if this command can be executed; otherwise, false.

### CanExecuteChanged

Raised when RaiseCanExecuteChanged is called

### Execute(parameter)

Executes the <a href="#relaycommand">RelayCommand</a> on the current command target

| Name | Description |
| ---- | ----------- |
| parameter | *System.Object*<br>Data used by the command. If the command does not require data to be passed, this object can be set to null |

### RaiseCanExecuteChanged

Method used to raise the <a href="#relaycommand.canexecutechanged">RelayCommand.CanExecuteChanged</a> event to indicate that the return value of the <a href="#relaycommand.canexecute(system.object)">RelayCommand.CanExecute(System.Object)</a> method has changed


## RemovePlaylistItemRequest

Remove Playlist Item Request

### Positions

Items to remove from their current positions in the playlist. Zero-indexed, that is the first item in the playlist has the value 0, the second item 1, and so on to a maximum of a 100 items


## RequestExtensions

Request Extension Methods

### All(searchTypeRequest)

All

| Name | Description |
| ---- | ----------- |
| searchTypeRequest | *Spotify.NetStandard.Sdk.SearchTypeRequest*<br>SearchTypeRequest |

#### Returns

SearchTypeRequest


## ResponseArgs

Response Arguments

### Index

Index

### Items

List of Response Items


## ResponseErrorArgs

Response Error Arguments

### Constructor(error)

Constructor

| Name | Description |
| ---- | ----------- |
| error | *Spotify.NetStandard.Sdk.ErrorResponse*<br>Status |

### Error

Error Response


## ResponseMovedArgs

Response Moved Arguments

### SourceIndex

Source Index

### TargetIndex

Target Index

### Total

Total Items


## ResponseRemovedArgs

Response Removed Arguments

#### Type Parameters

- TResponse - Response Type

### Index

Index

### Item

Item

### Items

List of Response Item


## ResponseUserPlaybackArgs

Response User Playback Arguments

### Constructor(playbackType, deviceId)

Constructonr

| Name | Description |
| ---- | ----------- |
| playbackType | *Spotify.NetStandard.Sdk.PlaybackType*<br>Playback Type |
| deviceId | *System.String*<br>Device Id |

### DeviceId

Device Id

### PlaybackType

Playback Type


## ResumePointResponse

Resume Point Response

### FullyPlayed

Whether or not the episode has been fully played by the user

### ResumePosition

The user’s most recent position in the episode in milliseconds


## SavedType

Saved Type

### Album

Album

### Show

Show

### Track

Track


## SearchRequest

Search Request

### Country

(Optional) Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### External

(Optional) Include any relevant audio content that is hosted externally

### Query

(Required) Search Query

### SearchTypeRequest

(Required) Search results include hits from all the specified item types


## SearchResponse

Search Response

### Albums

Albums

### Artists

Artist

### Episodes

Episode

### Playlists

Playlist

### Shows

Show

### Tracks

Track


## SearchTypeRequest

Search Type Request

### Album

Album

### Artist

Artist

### Episode

Episode

### Playlist

Playlist

### Show

Show

### Track

Track


## SectionResponse

Section Response

### Key

The estimated overall key of the section. The values in this field ranging from 0 to 11 mapping to pitches using standard Pitch Class notation

### KeyConfidence

The confidence, from 0.0 to 1.0, of the reliability of the key

### KeyConfidencePercentage

The confidence percentage, from 0% to 100%, of the reliability of the key

### KeyString

The estimated overall key of the section. The values in this field using standard Pitch Class notation of C, C♯, D, D♯, E, F, F♯, G, G♯, A, A♯ or B

### Loudness

The overall loudness of the section in decibels (dB)

### LoudnessValue

The overall rounded loudness of the section in decibels (dB)

### MeterString

Meter is the estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure) of 3/4, 4/4, 5/4, 6/4 and 7/4

### Mode

Indicates the modality (major or minor) of a track, the type of scale from which its melodic content is derived.This field will contain a 0 for “minor”, a 1 for “major”, or a -1 for no result

### ModeConfidence

The confidence, from 0.0 to 1.0, of the reliability of the mode

### ModePercentage

The confidence percentage, from 0% to 100%, of the reliability of the mode

### ModeString

Indicates the modality of a track, the type of scale from which its melodic content is derived which can be Major, Minor or Empty String

### Tempo

The overall estimated tempo of the section in beats per minute (BPM)

### TempoConfidence

The confidence, from 0.0 to 1.0, of the reliability of the tempo

### TempoConfidencePercentage

The confidence percentage, from 0% to 100%, of the reliability of the tempo

### TempoValue

The overall estimated rounded tempo of the section in beats per minute (BPM)

### TimeSignature

An estimated overall time signature of a track. The time signature (meter) is a notational convention to specify how many beats are in each bar (or measure). The time signature ranges from 3 to 7 indicating time signatures of “3/4”, to “7/4”

### TimeSignatureConfidence

The confidence, from 0.0 to 1.0, of the reliability of the time_signature

### TimeSignatureConfidencePercentage

The confidence percentage, from 0% to 100%, of the reliability of the Time Signature


## SegmentResponse

Segment Response

### LoudnessEnd

The offset loudness of the segment in decibels (dB)

### LoudnessMax

The peak loudness of the segment in decibels (dB)

### LoudnessMaxTime

The segment-relative offset of the segment peak loudness in seconds

### LoudnessStart

The onset loudness of the segment in decibels (dB)

### Pitches

A “chroma” vector representing the pitch content of the segment, corresponding to the 12 pitch classes C, C#, D to B, with values ranging from 0 to 1 that describe the relative dominance of every pitch in the chromatic scale

### Timbre

Timbre is the quality of a musical note or sound that distinguishes different types of musical instruments, or voices


## SetPlaylistRequest

Set Playlist Request

### PlaylistId

(Required) Spotify Playlist Id


## SetType

Set Type

### Add

Add

### Remove

Remove


## ShowResponse

Show Response

### AddedAt

ShowType.UserSaved Only - The date and time the show was saved. Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ. If the time is imprecise (for example, the date/time of an show release), an additional field indicates the precision; see for example, ReleaseDate in a show object.

### AddUserPlaybackCommand

Start/Resume a User's Playback

### AvailableMarkets

A list of the countries in which the show can be played, identified by their ISO 3166-1 alpha-2 code

### Copyrights

The copyright statements of the show

### Description

A description of the show

### Episodes

A list of the show’s episodes.

### Images

The cover art for the show in various sizes, widest first

### IsExplicit

Whether or not the show has explicit content ( true = yes it does; false = no it does not OR unknown)

### IsExternallyHosted

True if all of the show's episodes are hosted outside of Spotify’s CDN

### Languages

A list of the languages used in the show, identified by their ISO 639 code

### Large

Large Image

### MediaType

The media type of the show

### Medium

Medium Image

### PlaybackStartType

Playback Start Type

### Publisher

The publisher of the show

### Small

Small Image

### ToggleFavourite

Toggle Favourite Show

### ToggleSaved

Toggle User's Saved Show


## ShowsRequest

Shows Request

### Country

(Optional) Only for ShowType.Search, ShowType.Multiple and ShowType.UserSaved - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### MultipleShowIds

(Required) Only for ShowType.Multiple - Multiple Spotify Show Ids

### SearchIsExternal

(Optional) Only used for ShowType.Search - If true the response will include any relevant audio content that is hosted externally

### ShowType

(Required) Show Type

### Value

(Required) Only for ShowType.Search - Show Search Term


## ShowType

Show Type

### Favourite

Favourite Shows

### Multiple

Multiple Shows

### Search

Search for Shows

### UserSaved

User's Saved Shows


## SnapshotResponse

Snapshot Response

### SnapshotId

Can be used to identify playlist version in future requests


## SpotifySdkClientFactory

Spotify Sdk Client Factory

### CreateSpotifySdkClient(clientId, clientSecret, authorisationRedirectUri, authorisationState)

Create Spotify SDK Client

| Name | Description |
| ---- | ----------- |
| clientId | *System.String*<br>(Required) Spotify Client Id |
| clientSecret | *System.String*<br>(Optional) Spotify Client Secret |
| authorisationRedirectUri | *System.Uri*<br>(Optional) Authorisation Redirect Uri |
| authorisationState | *System.String*<br>(Optional) Authorisation State |

#### Returns

Spotify SDK Client


## StatusFailedArgs

Status Failed Arguments

### Constructor(status)

Constructor

| Name | Description |
| ---- | ----------- |
| status | *Spotify.NetStandard.Sdk.StatusResponse*<br>Status |

### Status

Status Response


## StatusResponse

Status Response

### Code

Code

### StatusCode

Status Code

### Success

Success


## TimeIntervalResponse

Time Interval Response

### Confidence

The reliability confidence, from 0.0 to 1.0

### ConfidencePercentage

The reliability confidence percentage, from 0 to 100%

### Duration

The duration in seconds

### Start

The starting point in seconds


## Toggle

Toggle

### Command

Command

### Id

Id

### ItemType

Item Type

### ToggleType

Toggle Type

### Value

Value


## ToggleType

Toggle Type

### Favourites

Favourites

### Follow

Follow

### Saved

Saved


## TrackResponse

Track Response

### AddedAt

TrackType.UserSaved Only - The date and time the track was saved. Timestamps are returned in ISO 8601 format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ. If the time is imprecise (for example, the date/time of an album release), an additional field indicates the precision

### AddPlaylistItemCommand

Add Item to a Playlist

### AddUserPlaybackCommand

Start/Resume a User's Playback

### AddUserPlaybackQueueCommand

Add an item to the end of the user's current playback queue

### Album

The album on which the track appears. The album object includes a link in href to full information about the album

### Artist

Artist Response

### Artists

The artists who performed the track. Each artist object includes a link in href to more detailed information about the artist.

### AudioAnalysis

Audio Analysis for Track

### AudioFeatures

Audio Features for Track

### AvailableMarkets

A list of the countries in which the track can be played, identified by their ISO 3166-1 alpha-2 code.

### Context

TrackType.UserRecentlyPlayed Only - The context the track was played from

### DiscNumber

The disc number (usually 1 unless the album consists of more than one disc).

### Duration

The track length in milliseconds.

### DurationTimeSpan

Duration Timespan

### ExternalId

Known external IDs for the track.

### GetAudioAnalysisCommand

Get Audio Analysis for a Track Command

### GetAudioFeaturesCommand

Get Audio Features for a Track Command

### Images

Images in various sizes, if available

### IsExplicit

Whether or not the track has explicit lyrics ( true = yes it does; false = no it does not OR unknown).

### IsLocal

Whether or not the track is from a local file

### IsPlayable

Part of the response when Track Relinking is applied. If true , the track is playable in the given market. Otherwise false.

### Large

Large Image

### Length

Track Length

### LinkedFrom

Part of the response when Track Relinking is applied and is only part of the response if the track linking, in fact, exists

### Medium

Medium Image

### PlaybackStartType

Playback Start Type

### PlayedAt

TrackType.UserRecentlyPlayed Only - The date and time the track was played. Format yyyy-MM-ddTHH:mm:ss

### PlayItemType

Play Item Type

### Popularity

The popularity of the track. The value will be between 0 and 100, with 100 being the most popular

### Preview

A link to a 30 second preview (MP3 format) of the track

### Restrictions

Part of the response when Track Relinking is applied, the original track is not available in the given market

### Seeds

TrackType.Recommended Only - An array of recommendation seed objects

### Small

Small Image

### ToggleFavourite

Toggle Favourite Track

### ToggleSaved

Toggle User's Saved Track

### TrackNumber

The number of the track. If an album has several discs, the track number is the number on the specified disc


## TrackRestrictionResponse

Track Restriction Response

### Reason

Contains the reason why the track is not available e.g. market


## TracksRequest

Tracks Request

### Country

(Optional) Only used for TrackType.Search, TrackType.Album, TrackType.Artist and TrackType.UserSaved - Overrides Client Country as ISO 3166-1 alpha-2 country code e.g. GB

### MultipleTrackIds

(Required) Only for TrackType.Multiple - Multiple Spotify Track Ids

### Recommendation

(Optional) Only used for TrackType.Recommended where Value not Provided - Recommendation Request

### SearchIsExternal

(Optional) Only used for TrackType.Search - If true the response will include any relevant audio content that is hosted externally

### TrackType

(Required) Track Type

### Value

(Required) Only for TrackType.Search - Track Search Term, TrackType.Recommended - Genre, TrackType.Album - Spotify Album Id and TrackType.Artist - Spotify Artist Id


## TrackType

Track Type

### Album

Album Tracks

### Artist

Artist Top Tracks

### Favourite

Favourite Tracks

### Multiple

Multiple Tracks

### Recommended

Get Recommendations

### Search

Search for Tracks

### UserRecentlyPlayed

User's Recently Played Tracks

### UserSaved

User's Saved Tracks

### UserTop

User's Top Tracks


## TuneableTrackRequest

Tuneable Track Request

### Acousticness

A confidence measure from 0.0 to 1.0 of whether the track is acoustic

### Danceability

Danceability describes how suitable a track is for dancing based on a combination of musical elements including tempo, rhythm stability, beat strength, and overall regularity

### Duration

The duration of the track in milliseconds

### Energy

Energy is a measure from 0.0 to 1.0 and represents a perceptual measure of intensity and activity

### Instrumentalness

Predicts whether a track contains no vocals

### Key

The key the track is in. Integers map to pitches using standard Pitch Class notation

### Liveness

Detects the presence of an audience in the recording

### Loudness

The overall loudness of a track in decibels (dB)

### Mode

Mode indicates the modality(major or minor) of a track, the type of scale from which its melodic content is derived

### Popularity

The popularity of the track. The value will be between 0 and 100, with 100 being the most popular

### Speechiness

Speechiness detects the presence of spoken words in a track

### Tempo

The overall estimated tempo of a track in beats per minute (BPM)

### TimeSignature

An estimated overall time signature of a track.

### Valence

A measure from 0.0 to 1.0 describing the musical positiveness conveyed by a track


## UserResponse

User Response

### DisplayName

The name displayed on the user’s profile. null if not available.

### Followers

Information about the followers of this user.

### Images

The user’s profile image.

### Large

Large Image

### Medium

Medium Image

### Small

Small Image

### ToggleFollow

Toggle Following State for User

### TotalFollowers

The total number of followers.


## UserTopTimeRangeType

User Top Time Range Type

### LongTerm

Calculated from several years of data and including all new data as it becomes available

### MediumTerm

Approximately last 6 months

### ShortTerm

Approximately last 4 weeks

