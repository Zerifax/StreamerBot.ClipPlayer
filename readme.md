# Streamer Bot Clip Helper

## Features

Originally inspired by the streamer bot video shout out this has grown well beyond the original scope. This can be used as a drop-in replacement for the original shout out but it provides some additional functionality:

- Video source: Embed any video source in your overlay
- Media controls: Play, pause, rewind and fast forward clips and videos embedded in your overlay.
- Playback progress: Progress indicator at the bottom of the video

## Building

Build the Zerifax.ClipHelper project and copy the following assemblies into the root of the Streamer Bot folder:

- Zerifax.ClipHelper.dll
- Newtonsoft.Json.dll

## Setup

The clip player functionality depends on the built in websocket server for Streamer Bot and triggers two of the actions from the import section below.

Setup a new custom websocket server with the following settings. Note the connected and message actions. You can pick a different address if you need to.

![Websocket Settings](websocket.png)

The connected action is used to capture the session used for media controls. The message action is used to hide the overlay on completion.

Some settings will need to be changed in the actions.

Play Clip: 
- Edit ClipBrowserSource and ClipScene to match your source in OBS.
- Edit ClipFile to point to the clip.html file.
- Edit ClipWebSocket only if needed.
- Update the references to OBS elements as needed. Currently this is set up for a browser source with an image backgrounds.
- Add references to the assemblies built above.

Set Clip:
- Update the references to OBS elements as per the play clip action.

If you wish to automatically detect twitch clips in messages (and you allow URL's in chat) you can create a command that calls the SetClip action. For this command I use a regex to automatically detect clips but you can create a custom command if you desire.

The command regex I use is: `https://clips.twitch.tv/[^\s]+`


## Actions Import

Import the actions into streamer bot before setting up the websocket.

TlM0RR+LCAAAAAAABADtXFtzIjmyft+I/Q9Ev+6orZLqpo7YB4MNBtu0AbsKWE9s6FZQprgsxX1j/vtJFWDTGM8xM6Z3Zrcd4TYulVKpT6kvlZly//uvf8nlPs30OI2Hg09fctZP2YMB72v47dOn9a9cTqA5hSf/ML/ncv9e/4CmWJn3fK6IIwlGrnQcZAsfIyYER9iRgkrfcuGFtays07+memrkD6ZJ8vJUD7hItJE3GU/1y/OtMg09yRWSeLQjqDMeTkdZW3c4neS+TifpTitP5nyZ1qdmYhFP0h2ZYz5Qw/55Nq/XrXI4kNPxWA8mr5R5BcU3cHyj74sm2WOlUzmOR5sR91t7Wo/Ok3imX2mz1ldHGvSRem/krLHw5fExjGFC8/Tx8TaW42E6jCafq5f3j4/FMWgzH457j48z+zP+TDG12ONjP5XDcRKLzypJvtXkt8lrLNOJ7mfSdoX9/O0sxHKiC0OVoaOa1ZHoy84DTVaqFEy+zvH1/rObpJ7oq9r0oR8MVLjoyl5gy6tKIim8R5zVwT696kyUFkmL1rN3bnoqEf1gycNb76I2rBYGeavVX4xay/yTKBVXcpm/eLjsVgQ8E/0HaE+rhU4yV2ElhT6dVp/NRCFf1KXgSTXryXWhZ9qNrEqhWcWyn0zby/y81azjdrMyLV/gTq1QGaqr+lyuhrMbUk15M7+6GdQpb9afeMHBKmaimSxWzUYamzkUakZmryJpHfR0BuVSMpVXATayWs3KQFppLPtF2giduWrW4mbDeRDWduzOaC0jabRDlehLNlelZCYGtx1B85iHbCqX56xcrCRtEtj3z8+cKmAKn7N5d6JCfr//tBGqqaCVpEaKq/a9wSUbp2+etcLqsFzoVlvZnPITo/N2jJue1VWl6rDdvB3ytc5p+SrfBUwS2bfTcul5jNF1LZO5xrOWwFp0pg8kwHWymLX6xTToF5fXhUraAqxbZDGShTL0x9M6rcwU4Bqu8uomaXfFVZDcFPL9VrhYtRu99VoDpoWwsmyHxfHX5XmnXHj1nb0TgQ7r9awk6ipYijiP5SBIMlybGGwCvjt///venh2NtRz2R3HyxqZVOuHLxoSPJ4fbN9ypiE84cxDX1EI2iwjilHFEMPEtJmylbGdv4LmOO10jFH/G37ZMliOjDDNf37ZsqfIbzl2rMVB6YYS9PP1l+/HnfeYrGTEZCf28y5dJwkepVjut68ZffjrsMETkcNfFBHncF+AwtIuERSMktKQc5h0pmx5wGJ+YoAQzbCHLotAvsjESXGHkOTYAxX3uR/LT+13KHSzQf8Kn7LW9w6nMeDJ99oKTrs51J/0kN4uVHuZSo6jRNTKmeMjGHN+WnutpwBfMy460Z5AWiHo8styIUYzpsTZmYfyGie37tq2B0R0D++ldE10Op+NcKvVA5wDc3FyLnBiDW9LwFJqkzs34ODZrnOa64CAPTp770o247yKsqAJbA+thHhdI2Jj6BGsWMf/jJv++/fXm9OGUMIkHfGNDe4NvJ1vdmK+x3IZBZ5+YzHkOHPIrw89a18g9H/YOIJ8BjnJXU3UQUIph53LA0lGMItuLbMSZB/9gKrltu1x6+GhACTkWT3ISPPNr+2qsQfpQXIPG14N4Ks9TwPs+srAFeEqXIsaFhSIqZeRF0vGZ9R3wtE6CZ/E1J/1OGA3LfTk7Oyt8OUsnY837Z+dpqifp2Swafja0eBBkF0BUXPoIRxpYgILT4IwRRFzJmO1jrPyj3exvANl+D8gZ421BDGPVASo8tB3XUG1ffG1e6YRP9OtlAlc00JnLKWfQ4M0XOvDP9usgphZ2HekIcMSO7yGbQNgnLEFQpKmmVEnbio5mVooPQ/qWU/FPCmguPxwrPf7OuHLfERF2JVLcAlv1IwWEwHwEUMOxKcKSWfzUuLL34PpfEeqej0YgrJFRiR5/FsPJ42Nbj+OILz4bBrvSCTDWUd2rej6BA51RrZIOBx8cZReGY/3HCdxvehBADi4h4BpZkmTBMIdAeNTuFyEQzILfcjtczNvN8u479xoCunaIp0EpsFXBMcGnBQH5st7szmU/WMF7JkDcD9oh0K5A0FqEILBqgsJV+bJaa1wmUwEBaBsCOZ0Fbfklb7YhCH3oNEpBKkvBslxkwxc9hhXzDUF2DP2eypfdRFzlExk/6/oS5ENQrM6/CVJH7fh82CTbPufsrpGfQjCdroPZXkWvg/pKIXges2PeaTflsz7XhV5HY8AnDKbqMulliQMrXzYJC3WpUkEqXVFsd+XTYqWuKgbzv0Eg/KBIAoFwNy9LyQXonohBLYbANwtYr5t4qyN7DoBfgtqIb8beJAzMO8/B7zMWpcpMkHkH1iFp0QC3G52RaV/PKSEtmIsk1cQkDWBOWcBe3wvY7642yYmVPSyvbeC+RYJpuwHB+1V9qcKHbdJiI49Zsl9N3omBmfe8NqjMFK0mMqnOVLPy9JZsRYL4gbAnTtYJlffKD6Cf3PaL5x1otzaJBcAU+sR5wsN6Iqw82GGSyF57JEpHYVLi4SJ5Jbv2ovs64XHOMhsvOFftZv1KlFjcChchtPvbhNFd3IlNMkuVjNzzeC8RUik8ZP1vBVEV0W/PYIC4lsnOj+Qy72XjXOH4+iXJs1mXhdW21kkdg53oB3Sb5LkulKfXsT+8Wy1W4ioY3CUTfWPh8XWjc/Y19s+uG7U35UkapMrM66qaqlCtE08FZ5NM6j4Z/Hf6Zvut3Ny826xawiQFafAENrWSy3XybLvngDuwMom4tS1s1gtn7+ysXTZGvVTErYbBd7uXM4wvXtq62dwegI9MsgzsZiloMM8ScmYuy8pz8mlf3wzTyzpw0GXn7h6wGwSpKLxX1z0bKOaX7WZ7ZPjjbsMxZi1CC3f0OsF4Cdh1b5I6cHEv48aXZ9UJ2EIKNrEzZ6faDusjFVrsBuxWDqr4nlYu2yFwJszz+nzDX+Et6G53ys+JTqcisQM8vbiTiRryZj15oPluizwMW8tetu/WnJn0y4Xudk9NG83qV8OPMEaTlxLcDqrzVlhNrtd61gAH2EsBvW4cuZZru76HNcvLPvgPw6WFTrzGvrIUpNhrEbMvgP9hn+2sydTwRyusP5nEIvDz2U2vPpI028tfW6G1Wc9eJeOLpAp8UVy2aTBphw4oV8mwDGAusOfjPWwfAJd0b++9oWMdeK+YJWT39asDZ8P6mST2fTuszkS/vnqfTl0YozJthUkaNCvps9wXGxrtJp1VP+m1Q1YD/nDAb685qZCycqF8Br4+kU84ht+Pwm7Lv4f48XqFO+UYPofFQfv+HbKTPKyj6RtUsj5B0Li/SP8/3ftqB4cmBf93sTPWCxYbH5/AmuRB1qKrDR9cyPlt4XwMNgz7qTb6Zj/1XtbsgQRPsD49uTz/V/nicn57cb71D6N2KZg9lEBeGCzr/QTs4Xx81ziPKwNY0/CBleNM/mbM4QL6zrfr+6vz2vFLd41y53qZp+2wci9Iddxu1p4T32s/x2JpGTuBvUDVCmTdA38tzX7d+HDwmVv/CX7owLhbnW6WDDinapLp4FfymMNawhxhbXsdaQopJOjBPp3B9xDaV5txOq1Br3Mb51dbGy6X2jPg39TsTeO7Mrwa/mwry9jH7eocsHweN/OnASmO1DNem70F/X7LPMv9Ygzt+Gu/krZCZ1yOXwoGhzjHnJGi2okKAK7QvsMtGzmaOchmnkbMgzCRC+HZmnval/LYaO9XCgBvBXzWx+cn7+fxRHbPRzGEUSbx/aFpoF7cH2jP7y3oQC5cMe4M7f7Mnfdip2v1hofjakdIR9oc2RbWyI4oRcxS8ElpiTklhLGj4+o3c0Bv4eydJM0WapEOZU9/MMjz9MvZmUU8CBjxZ+sLwwyfHU4FSV9GEbeQKcIgG7BE3OYcRRalmrlgjcI+ObTu0QUGU0mZb6HLTceHc4fEU57EQiPhWzA5l3rIJ4ogS3iRSwjsXnH0Dj2+fOLszG778VT1OUdKh/i+haRW2KT3fCQiWyHpUu75nibUF9+hPteYDEd/ijsfH52x3duPH5ZZtInFue85yLUlrCt3FRJmhZlLBPMsLIAPPyqz+DsrYSfK2Z4KWZdLJj0b9gnTgKzluogxL0LawwK7kef7rnd6ZN9Vw/koYzV0abyqgH34RSR80Pt0InCZ6wuihUJaMB/ZvmsBrQg4IjnSsRzH8VV0dMWR+r+n4HhqAvYd2yGRjJBjgyu1tU8Rd6WDHAa7V2vpWbZ3gICPu1EXNnK3WsU8t6525grr9TpEts/niz8A2R51OAob/wzMLYmGTtd2+JvOR68G2ZwhUp0eFLteRB1JJRxbIsZh6WyLgtm6cPIEl0iBbh1C6H5t9BQ1x+95sUf5lsWwtlBkLoHaFEdwDvQlMrcCtCMYpQx/nN2a+ztnd3ya6u9ss8df4HnblD7QXnd2RrCR+2tWqnTEp8kk2FjzAQva3E+IHCYjghRTsJJKSsSJayPLcyPHYw5X6mjXZhHr95jxf09FclfckddlL2qjl2uqZNGV9DarbjRCB545CbR7R1R2NlmWl+xSjQYwFps8kGCp+sFyNzN3XajMTZYoyy5ur6iSTdWul/TKianssftNBnh4/Vw5+Q9csaQaM2ExiXwwZGTb0kbMtiLkS275kVDC86PvcsVy93h2aia2hA9hN8RszGdwgnAcOOXbkYsohcOU1o5Hdy9n/F4mrus5TPIHC+dOxsKSy+w6MCJCwBlY2TaEGp6HsA+2TKgn4Fj4g4X/11i47N9lF+JNHagqyoPq9o8jKu2CqU3WZw+bGvF1obetiy/bTVPDsNd15yy/b+4CjMx9gNMwsNB2FAmPIAsTjmzgXSR8cwVP24RpN9KR930uuX9PBqbYdiMiXOTb2Aa345jkAPOQE2Hb8ggchzH5OAbOc9n7wb+5k/Gvg31lCywgmDPxDBUReFbfQZoqqoGITUj3g3//9/j3T3EChlDNcgmHIy/mtslOasRcaSHlEk+7WDKKjw7h/vD861PpO57nIM9M1ZZulpz1kev4AmZPmE0+kH+Lw/Gcj38cgbPW01AwtiziRTZFlAEP24xz5BMZIUK542Gfuy45/i95flDwn52C//anoGDfs32LQujmUjgS2nZEEacuR46rCNZAR7Z1dIX8D0/BtrIwV9hCxPUosrGDkYiwB3sX4wjLyJGO83EUfAv0wjt//FzwPtUqPtm/dzIEft1WON66nJFOhqOR3udS/lJwe20D4+mg3O8bsCY6WR42Vx5N9Ph55tYhWyaRZ7u25yK2LvNjB/kWp8gB9yo8bNkeFscT8WnqyFu4LIz3Bujzxdbj7LWsV//XdjOHaIAorpArJDfZNQYHquxyiGUJ7tmREMdfJcL4yAsv7yr37hjEkfc61lhsTGZrMa+d/aZGK7WHFXOQ4wjzd+wa4l5JFfIsbFOHOR6xj/4bY/tYizhJidb8WL+5Jqhf+Y9Qjrz/IhLgpHjQec0iW26r6xE4l0+7mvz1L7/8H7hMWZC3RQAA