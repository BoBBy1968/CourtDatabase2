//// GET: Courts/Edit/5
//public async Task<IActionResult> Edit(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var court = await _context.Courts.FindAsync(id);
//    if (court == null)
//    {
//        return NotFound();
//    }
//    ViewData["CourtTownId"] = new SelectList(_context.CourtTowns, "Id", "Address", court.CourtTownId);
//    return View(court);
//}

//// POST: Courts/Edit/5
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Edit(int id, [Bind("Id,CourtType,CourtTownId")] Court court)
//{
//    if (id != court.Id)
//    {
//        return NotFound();
//    }

//    if (ModelState.IsValid)
//    {
//        try
//        {
//            _context.Update(court);
//            await _context.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!CourtExists(court.Id))
//            {
//                return NotFound();
//            }
//            else
//            {
//                throw;
//            }
//        }
//        return RedirectToAction(nameof(Index));
//    }
//    ViewData["CourtTownId"] = new SelectList(_context.CourtTowns, "Id", "Address", court.CourtTownId);
//    return View(court);
//}
//--------------------------------------------------------------------------------------------------------
//public async Task<IActionResult> Create([Bind("Id,CourtType,CourtTownId")] Court court)
//{
//    if (ModelState.IsValid)
//    {
//        _context.Add(court);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }
//    ViewData["CourtTownId"] = new SelectList(_context.CourtTowns, "Id", "Address", court.CourtTownId);
//    return View(court);
//}
//------------------------------------------------------------------------------
// GET: Courts/Details/5
//public async Task<IActionResult> Details(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var court = await _context.Courts
//        .Include(c => c.CourtTown)
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (court == null)
//    {
//        return NotFound();
//    }

//    return View(court);
//}

//// GET: Courts/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var court = await _context.Courts
//        .Include(c => c.CourtTown)
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (court == null)
//    {
//        return NotFound();
//    }

//    return View(court);
//}

//// POST: Courts/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    var court = await _context.Courts.FindAsync(id);
//    _context.Courts.Remove(court);
//    await _context.SaveChangesAsync();
//    return RedirectToAction(nameof(Index));
//}
