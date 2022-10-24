#pragma once

#include "resource.h"

wchar_t* GetWC(const char* c)
{
    size_t size = strlen(c) + 1;
    wchar_t* out = new wchar_t[size];

    size_t outSize;
    mbstowcs_s(&outSize, out, size, c, size - 1);

    return out;
}