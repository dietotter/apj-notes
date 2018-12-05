#!/bin/bash
dotnet ef migrations add `date "+%m%d%Y%H%M%S"` -c ReminderContext -o Data/Migrations