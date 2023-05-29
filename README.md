[![Github All Releases](https://img.shields.io/github/downloads/Misaka-SL-Project/EndConditions/total.svg)](https://github.com/Misaka-SL-Project/EndConditions/releases) 
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://github.com/Misaka-SL-Project/EndConditions/graphs/commit-activity)
# EndConditions
- Grants the ability to set custom round end conditions using [EXILED](https://github.com/Exiled-Team/EXILED/).

## EXILED Configs:
| Config Option | Value Type | Default Value | Description |
|:------------------------:|:----------:|:-------------:|:------------------------------------------:|
| `is_enabled` | bool | true | Enables/Disables the plugin. |
| `file_name` | bool | global.yml | The name of the file to store the win conditions config in. |
| `end_on_detonation` | bool | false | Whether Detonation Winner will be used. |
| `detonation_winner` | LeadingTeam | FacilityForces | The team that will win when the warhead detonates. |
| `ignore_tutorials` | bool | true | Whether tutorials will be ignored while checking if the round should end. |
| `round_end_ff` | bool | false | Whether friendly fire will be enabled when the round ends. |

- The win condition configs file for EndConditions is located at __/EXILED/Configs/EndConditions/global.yml__ by default.

## Leading team names:
- FacilityForces
- ChaosInsurgency
- Anomalies
- Draw

## Class names
- Scp173
- Scp106
- Scp049
- Scp079
- Scp096
- Scp0492
- Scp939
- NtfScientist
- ChaosConscript
- ChaosRifleman
- ChaosRepressor
- ChaosMarauder
- NtfLieutenant
- NtfCommander
- NtfCadet
- FacilityGuard
- Scientist
- ClassD
- Tutorial

## Default Plugin Configs:
```
conditions:
  Draw:
  - name: 'Chaos Draw'
    escape_condition:
      class_d: Restricted
      scientists: Required
    role_conditions:
    - 'ChaosConscript'
    - 'ChaosRifleman'
    - 'ChaosRepressor'
    - 'ChaosMarauder'
  - name: 'MTF Draw'
    escape_condition:
      class_d: Default
      scientists: Restricted
    role_conditions:
    - 'NtfCaptain'
    - 'NtfSergeant'
    - 'NtfPrivate'
    - 'NtfSpecialist'
    - 'FacilityGuard'
    - 'Scientist'
  - name: 'SCP Draw'
    escape_condition:
      class_d: Restricted
      scientists: Default
    role_conditions:
    - 'Scp173'
    - 'Scp106'
    - 'Scp049'
    - 'Scp079'
    - 'Scp096'
    - 'Scp0492'
    - 'Scp93953'
    - 'Scp93989'
    - 'ChaosConscript'
    - 'ChaosRifleman'
    - 'ChaosRepressor'
    - 'ChaosMarauder'
  FacilityForces:
  - name: 'MTF Victory'
    escape_condition:
      class_d: Default
      scientists: Required
    role_conditions:
    - 'NtfCaptain'
    - 'NtfSergeant'
    - 'NtfPrivate'
    - 'NtfSpecialist'
    - 'FacilityGuard'
    - 'Scientist'
  Anomalies:
  - name: 'SCP Victory'
    escape_condition:
      class_d: Restricted
      scientists: Default
    role_conditions:
    - 'Scp173'
    - 'Scp106'
    - 'Scp049'
    - 'Scp079'
    - 'Scp096'
    - 'Scp0492'
    - 'Scp93953'
    - 'Scp93989'
    - 'ChaosConscript'
    - 'ChaosRifleman'
    - 'ChaosRepressor'
    - 'ChaosMarauder'
  ChaosInsurgency:
  - name: 'Chaos Victory'
    escape_condition:
      class_d: Required
      scientists: Default
    role_conditions:
    - 'ClassD'
    - 'ChaosConscript'
    - 'ChaosRifleman'
    - 'ChaosRepressor'
    - 'ChaosMarauder'
  - name: 'Chaos Victory No ClassD'
    escape_condition:
      class_d: Required
      scientists: Default
    role_conditions:
    - 'ChaosConscript'
    - 'ChaosRifleman'
    - 'ChaosRepressor'
    - 'ChaosMarauder'
    - 'Scp173'
    - 'Scp106'
    - 'Scp049'
    - 'Scp079'
    - 'Scp096'
    - 'Scp0492'
    - 'Scp93953'
    - 'Scp93989'
```
